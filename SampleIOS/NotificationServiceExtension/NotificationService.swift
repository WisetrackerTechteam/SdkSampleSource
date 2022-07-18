//
//  NotificationService.swift
//  NotificationServiceExtension
//
//  Created by Green Shin on 2022/07/15.
//

import UserNotifications
import DOT

class NotificationService: UNNotificationServiceExtension {
  
  var contentHandler: ((UNNotificationContent) -> Void)?
  var receivedRequest: UNNotificationRequest!
  var bestAttemptContent: UNMutableNotificationContent!
  override func didReceive(_ request: UNNotificationRequest, withContentHandler contentHandler: @escaping (UNNotificationContent) -> Void) {
    self.receivedRequest = request
    self.contentHandler = contentHandler
    self.bestAttemptContent = DOT.didReceiveNotificationExtensionRequest(request, with: bestAttemptContent)
    if let bestAttemptContent = self.bestAttemptContent {
      contentHandler(bestAttemptContent)
    }
  }
  
  override func serviceExtensionTimeWillExpire() {
    // Called just before the extension will be terminated by the system.
    // Use this as an opportunity to deliver your "best attempt" at modified content, otherwise the original push payload will be used.
    if let contentHandler = contentHandler, let bestAttemptContent =  bestAttemptContent {
      contentHandler(bestAttemptContent)
    }
  }
  
}
