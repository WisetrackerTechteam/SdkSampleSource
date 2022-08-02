import { registerRootComponent } from 'expo';

import App from './App';

import PushNotificationIOS from "@react-native-community/push-notification-ios";
import PushNotification from "react-native-push-notification";

// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native';

// Must be outside of any component LifeCycle (such as `componentDidMount`).
PushNotification.configure({
  // (optional) Called when Token is generated (iOS and Android)
  onRegister: function (token) {
    console.log("TOKEN:", token);
    if (typeof token !== 'undefined' && typeof token.token !== 'undefined') {
      NativeModules.DotReactBridge.setPushToken(token.token);
    }
  },

  // (required) Called when a remote is received or opened, or local notification is opened
  onNotification: function (notification) {
    console.log("onNotification() => NOTIFICATION:", notification);

    // process the notification
    if (typeof notification !== 'undefined' && typeof notification.data !== 'undefined' && typeof notification.data.RW_push_payload_WP !== 'undefined') {
      let rw_notification = JSON.parse(notification.data.RW_push_payload_WP);
      if (typeof rw_notification !== 'undefined') {
        let title = rw_notification.RW_push_payload_TT;
        let body = rw_notification.RW_push_payload_BD;
        let deepLink = rw_notification.RW_push_payload_deeplink;
        console.log("onNotification() => rw_notification.title: , .body: , .deepLink: ", title, body, deepLink);
        // 푸시 메시지를 클릭할 때의 처리 (문자열로 변경)
        NativeModules.DotReactBridge.setPushClick(JSON.stringify(rw_notification));
      }
    }

    // (required) Called when a remote is received or opened, or local notification is opened
    notification.finish(PushNotificationIOS.FetchResult.NoData);
  },

  // (optional) Called when Registered Action is pressed and invokeApp is false, if true onNotification will be called (Android)
  onAction: function (notification) {
    console.log("ACTION:", notification.action);
    console.log("NOTIFICATION:", notification);

    // process the action
    if (typeof notification !== 'undefined' && typeof notification.data !== 'undefined' && typeof notification.data.RW_push_payload_WP !== 'undefined') {
      NativeModules.DotReactBridge.setPushReceiver(notification);
    }
  },

  // (optional) Called when the user fails to register for remote notifications. Typically occurs when APNS is having issues, or the device is a simulator. (iOS)
  onRegistrationError: function(err) {
    console.error(err.message, err);
  },

  // IOS ONLY (optional): default: all - Permissions to register.
  permissions: {
    alert: true,
    badge: true,
    sound: true,
  },

  // Should the initial notification be popped automatically
  // default: true
  popInitialNotification: true,

  /**
   * (optional) default: true
   * - Specified if permissions (ios) and token (android and ios) will requested or not,
   * - if not, you must call PushNotificationsHandler.requestPermissions() later
   * - if you are not using remote notification or do not have Firebase installed, use this:
   *     requestPermissions: Platform.OS === 'ios'
   */
  requestPermissions: true,
});

// registerRootComponent calls AppRegistry.registerComponent('main', () => App);
// It also ensures that whether you load the app in Expo Go or in a native build,
// the environment is set up appropriately
registerRootComponent(App);
