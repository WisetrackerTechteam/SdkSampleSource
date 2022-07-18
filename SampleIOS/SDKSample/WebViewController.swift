//
//  WebViewController.swift
//  SDKSample
//
//  Created by Green Shin on 2022/07/15.
//

import os
import UIKit
import DOT
import AdSupport

class WebViewController: UIViewController {
  
  @IBOutlet weak var webView: WKWebView!
  
  let logger = Logger(subsystem: Bundle.main.bundleIdentifier != nil ? Bundle.main.bundleIdentifier! : "Unknown" , category: "ProductViewController")
  
  override func viewWillAppear(_ animated: Bool) {
    super.viewWillAppear(animated)
    DOT.onStartPage()
    logger.debug("call DOT.onStartPage() on viewWillAppear()")
  }
  
  override func viewDidAppear(_ animated: Bool) {
    super.viewDidAppear(animated)
    logger.debug("call showAtt() on viewDidAppear()")
  }
  
  override func viewDidLoad() {
    super.viewDidLoad()
    // Do any additional setup after loading the view.
    logger.debug("on viewDidLoad()")
    
    // MARK: Wisetracker: WKWebView
    guard let url = Bundle.main.url(forResource: "main", withExtension: "html")
    else {
      logger.debug("path is nil")
      return
    }
    let request = URLRequest(url: url)
    webView.load(request as URLRequest)
    
    webView.uiDelegate = self
    webView.navigationDelegate = self
    webView.configuration.defaultWebpagePreferences.allowsContentJavaScript = true // Javascript 1 / 2
//    webView.configuration.preferences.javaScriptEnabled = true // Javascript 2 / 2
    
    // inject JS to capture console.log output and send to iOS
    let source = """
function captureLog(msg) { window.webkit.messageHandlers.consoleLogHandler.postMessage(msg); }
window.console.log = captureLog;
window.console.debug = captureLog;
"""
    let script = WKUserScript(source: source, injectionTime: .atDocumentEnd, forMainFrameOnly: false)
    webView.configuration.userContentController.addUserScript(script)
    // register the bridge script that listens for the output
    webView.configuration.userContentController.add(self, name: "consoleLogHandler")

  }

}

extension WebViewController: WKUIDelegate, WKNavigationDelegate {
  
  func webView(_ webView: WKWebView, didStartProvisionalNavigation navigation: WKNavigation!) {
    logger.debug("call DOT.injectSdk(toHtmlDocument: webView)")
  }
  
  func webView(_ webView: WKWebView, didFinish navigation: WKNavigation!) {
    logger.debug("call DOT.injectJavascript(withDomSearch: webView, isOnPageFinished: true)")
    DOT.injectJavascript(withDomSearch: webView, isOnPageFinished: true)
  }
  
  func webView(_ webView: WKWebView, didCommit navigation: WKNavigation!) {
    logger.debug("call DOT.injectJavascript(withDomSearch: webView, isOnPageFinished: false)")
    DOT.injectSdk(toHtmlDocument: webView, withStartPage: false)
  }
  
  func webView(_ webView: WKWebView, decidePolicyFor navigationAction: WKNavigationAction, decisionHandler: @escaping (WKNavigationActionPolicy) -> Void) {
    if let url = navigationAction.request.url{
      let absoluteString = url.absoluteString
//      FWLogger.log("url: \(absoluteString)")
      if (absoluteString.hasPrefix("jscall-dot")) {
        let request: URLRequest? = navigationAction.request
        DOT.setWkWebView(webView, reqeust: request)
        logger.debug("call jscall-dot > DOT.setWkWebView(webView, reqeust: request)")
        decisionHandler(.cancel)
      } else {
        decisionHandler(.allow)
      }
    } else {
      decisionHandler(.allow)
    }
  }
  
}

extension WebViewController: WKScriptMessageHandler {
  // inject JS to capture console.log output and send to iOS
  func userContentController(_ userContentController: WKUserContentController, didReceive message: WKScriptMessage) {
    switch message.name {
    case "consoleLogHandler" :
      logger.debug("javascript.console: \(message.debugDescription)")
      break
    default :
      logger.debug("\(message.name) : \(message.debugDescription)")
    }
  }
}
