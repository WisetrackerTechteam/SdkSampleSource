import UIKit
import Flutter
import DOT

@UIApplicationMain
@objc class AppDelegate: FlutterAppDelegate {
  override func application(
    _ application: UIApplication,
    didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey: Any]?
  ) -> Bool {
    GeneratedPluginRegistrant.register(with: self)
      
    /**
            Wisetracker SDK init
     **/
    DOT.initialization(launchOptions, application: application)
    return super.application(application, didFinishLaunchingWithOptions: launchOptions)
  }
}
