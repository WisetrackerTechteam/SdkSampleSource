//
//  AppTrackingPermission.swift
//  SDKSample
//
//  Created by Green Shin on 2022/07/15.
//

import os
import AdSupport
import AppTrackingTransparency

enum AppTrackingPermissionError: Error {
  case denied
  case notDetermined
  case restricted
}

class AppTrackingPermission {
  static let logger = Logger(subsystem: Bundle.main.bundleIdentifier != nil ? Bundle.main.bundleIdentifier! : "Unknown" , category: "AppTrackingPermission")

  static func requestAppTrackingPermission(completion: @escaping (Bool, AppTrackingPermissionError?) -> ()) {
    ATTrackingManager.requestTrackingAuthorization { status in
      switch status {
      case .authorized:
        self.logger.warning(".authorized \(status.rawValue)")
        completion(true, nil)
      case .denied:
        self.logger.warning(".denied \(status.rawValue)")
        completion(false, .denied)
      case .notDetermined:
        self.logger.warning(".notDetermined \(status.rawValue)")
        completion(false, .notDetermined)
      case .restricted:
        self.logger.warning(".restricted \(status.rawValue)")
        completion(false, .restricted)
      @unknown default:
        self.logger.error(".default \(status.rawValue)")
        break
      }
    }
  }
  
  func identifierForAdvertising() -> String? {
    // Get and return IDFA
    return ASIdentifierManager.shared().advertisingIdentifier.uuidString
  }
}
