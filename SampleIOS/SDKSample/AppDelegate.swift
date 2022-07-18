//
//  AppDelegate.swift
//  SDKSample
//
//  Created by Green Shin on 2022/07/14.
//

import os
import UIKit
import DOT

@main
class AppDelegate: UIResponder, UIApplicationDelegate {
  
  let logger = Logger(subsystem: Bundle.main.bundleIdentifier != nil ? Bundle.main.bundleIdentifier! : "Unknown" , category: "AppDelegate")
  
  func application(_ application: UIApplication, didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey: Any]?) -> Bool {
    // Override point for customization after application launch.
    
    registerForRemoteNotifications()
    
    return true
  }
  
  // MARK: UISceneSession Lifecycle
  
  func application(_ application: UIApplication, configurationForConnecting connectingSceneSession: UISceneSession, options: UIScene.ConnectionOptions) -> UISceneConfiguration {
    // Called when a new scene session is being created.
    // Use this method to select a configuration to create the new scene with.
    return UISceneConfiguration(name: "Default Configuration", sessionRole: connectingSceneSession.role)
  }
  
  func application(_ application: UIApplication, didDiscardSceneSessions sceneSessions: Set<UISceneSession>) {
    // Called when the user discards a scene session.
    // If any sessions were discarded while the application was not running, this will be called shortly after application:didFinishLaunchingWithOptions.
    // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
  }
  
  func application(_ app: UIApplication, open url: URL, options: [UIApplication.OpenURLOptionsKey : Any] = [:]) -> Bool {
    logger.debug("URL: \(url), options: \(options)")
    //    var handled: Bool
    //    handled = GIDSignIn.sharedInstance.handle(url)
    //    if handled {
    //      return true
    //    }
    // Handle other custom URL types.
    DOT.setDeepLink(url.absoluteString)
    
    // If not handled by this app, return false.
    return true
  }
  
  func application(_ application: UIApplication, handleOpen url: URL) -> Bool {
    logger.debug("url: \(url)")
    return true
  }
  
}


//
// MARK: 푸시 알림 extention
//
extension AppDelegate: UNUserNotificationCenterDelegate {
  
  // MARK: PushMessage: Regist
  
  private func registerForRemoteNotifications() {
    // 권한 요청
    let center = UNUserNotificationCenter.current()
    let options: UNAuthorizationOptions = [.alert, .sound, .badge]
    center.requestAuthorization(options: options) { (granted, error) in
      guard granted else {
        return
      }
      DispatchQueue.main.async {
        UIApplication.shared.registerForRemoteNotifications()
      }
    }
    center.delegate = self // push처리에 대한 delegate - UNUserNotificationCenterDelegate
  }
  
  // MARK: PushMessage: Regist
  
  func application(_ application: UIApplication,didRegisterForRemoteNotificationsWithDeviceToken deviceToken: Data) {
    let tokenParts = deviceToken.map { data -> String in
      return String(format: "%02.2hhx", data)
    }
    let token = tokenParts.joined()
    DOT.setPushToken(token)
    
    logger.info("token: \(token)")
  }
  
  func application(_ application: UIApplication,
                   didFailToRegisterForRemoteNotificationsWithError
                   error: Error) {
    // Try again later.
    logger.info("error: \(error.localizedDescription)")
  }
  
  // MARK: - UNUserNotificationCenterDelegate
  
  func userNotificationCenter(_ center: UNUserNotificationCenter, willPresent notification: UNNotification, withCompletionHandler completionHandler: @escaping (UNNotificationPresentationOptions) -> Void) {
    logger.debug("userInfo: \(notification.request.content.userInfo)")
    if let rootDict = notification.request.content.userInfo as NSDictionary? {
      if let dict = rootDict["RW_push_payload_WP"] as? NSDictionary {
        let title = dict["RW_push_payload_TT"]
        let body = dict["RW_push_payload_BD"]
        let deepLink = dict["RW_push_payload_deeplink"]
        
        logger.debug("Notification title: \(title.debugDescription), body: \(body.debugDescription), deepLink: \(deepLink.debugDescription)")
      }
    }
    completionHandler([.sound, .badge])
  }
  
  func userNotificationCenter(_ center: UNUserNotificationCenter, didReceive response: UNNotificationResponse, withCompletionHandler completionHandler: @escaping () -> Void) {
    DOT.setPushClick(response.notification.request.content.userInfo, application: UIApplication.shared)
    
    logger.debug("userInfo: \(response.notification.request.content.userInfo)")
    if let rootDict = response.notification.request.content.userInfo as NSDictionary? {
      if let dict = rootDict["RW_push_payload_WP"] as? NSDictionary {
        let title = dict["RW_push_payload_TT"]
        let body = dict["RW_push_payload_TT"]
        let deepLink = dict["RW_push_payload_deeplink"]

        // 푸시 데이터에 대한 처리를 이 곳에 구현
        logger.debug("Notification title: \(title.debugDescription), body: \(body.debugDescription), deepLink: \(deepLink.debugDescription)")
      }
    }
    completionHandler()
  }
  
  private func routeToScene(with pageName: String) {
    let storyBoard = UIStoryboard(name: "Main", bundle: Bundle.main)
    guard let mainViewController = storyBoard.instantiateViewController(withIdentifier: "MainViewController") as? MainViewController else { return }
    let sceneDelegate = UIApplication.shared.connectedScenes.first?.delegate as! SceneDelegate
    let rootViewController = sceneDelegate.window?.rootViewController
    rootViewController?.present(mainViewController, animated: true, completion: nil)
    
  }
  
}

