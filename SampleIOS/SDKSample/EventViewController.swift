//
//  EventViewController.swift
//  SDKSample
//
//  Created by Green Shin on 2022/07/15.
//

import os
import UIKit
import DOT
import AdSupport

class EventViewController: UIViewController {
  let logger = Logger(subsystem: Bundle.main.bundleIdentifier != nil ? Bundle.main.bundleIdentifier! : "Unknown" , category: "EventViewController")
  
  override func viewWillAppear(_ animated: Bool) {
    super.viewWillAppear(animated)
    // 이벤트 상세화면에 삽입하십시오
    let screen = NSMutableDictionary()
    screen["event"] = "w_view_event"
    screen["event_id"] = "E200905605"
    screen["event_name"] = "10월 COUPON PACK"
    DOT.logScreen(screen)
    
    logger.debug("call DOT.logScreen() on viewWillAppear()")
  }
  
  override func viewDidAppear(_ animated: Bool) {
    super.viewDidAppear(animated)
    logger.debug("call showAtt() on viewDidAppear()")
  }
  
  override func viewDidLoad() {
    super.viewDidLoad()
    // Do any additional setup after loading the view.
    logger.debug("on viewDidLoad()")
  }

}
