//
//  MainViewController.swift
//  WTExample
//
//  Created by Green Shin on 2021/11/25.
//

import os
import UIKit
import DOT
import AdSupport
import AppTrackingTransparency
import SnackBar_swift

class MainViewController: UIViewController {
  let logger = Logger(subsystem: Bundle.main.bundleIdentifier != nil ? Bundle.main.bundleIdentifier! : "Unknown" , category: "MainViewController")
  
  // 회원가입 이벤트를 최종 처리하기 위한 버튼
  @IBOutlet weak var buttonSignup: UIButton!
  
  // 로그인 이벤트를 최종 처리하기 위한 버튼
  @IBOutlet weak var buttonLogin: UIButton!
  
  // IDFA
  var idfa: String = ""
  
  override func viewWillAppear(_ animated: Bool) {
    super.viewWillAppear(animated)
    
    // 메인페이지가 열렸음을 기록
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
    
    // 회원 가입 이벤트 처리
    buttonSignup.addTarget(self, action: #selector(handleSignup(_:)), for: .touchUpInside)
    
    // 로그인 이벤트 처리
    buttonLogin.addTarget(self, action: #selector(handleLogin(_:)), for: .touchUpInside)
    
    if #available(iOS 12, *) {
      self.idfa = AppTrackingPermission.identifierForAdvertising() ?? ""
    } else {
      self.idfa = ASIdentifierManager.shared().advertisingIdentifier.uuidString
    }
    logger.debug("IDFA: \(self.idfa)")
  }
  
  @objc
  private func handleSignup(_ sender: UIButton) {
    // 앱에서 회원가입이 완료되는 시점에 삽입하십시오
    let event = NSMutableDictionary()
    event["event"] = "w_signup_complete"
    event["signupTp"] = "email"
    DOT.logEvent(event)
    
    SnackBar.make(in: self.view, message: "회원가입했어요", duration: .lengthLong).show()
    
    logger.debug("회원가입했어요.")
  }
  
  @objc
  private func handleLogin(_ sender: UIButton) {
    // 앱에서 로그인이 완료되는 시점에 삽입하십시오
    DOT.setUser(
      User.builder({ (builder) in
        let user = builder as! User
        // 성별, 연령, 고객등급을 아래와 같은 key, value로 더 추가 가능합니다
        user.gender = "male"
        user.age = "20-29"
        user.attribute1 = "platinum"
      })
    )
    let event = NSMutableDictionary()
    event["event"] = "w_login_complete"
    event["loginTp"] = "kakao"
    DOT.logEvent(event)
    
    SnackBar.make(in: self.view, message: "로그인했어요", duration: .lengthLong).show()
    
    logger.debug("로그인했어요.")
  }
  
}
