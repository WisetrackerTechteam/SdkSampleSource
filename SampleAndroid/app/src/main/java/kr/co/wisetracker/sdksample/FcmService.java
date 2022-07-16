package kr.co.wisetracker.sdksample;

import android.content.Intent;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.localbroadcastmanager.content.LocalBroadcastManager;

import com.google.android.material.snackbar.Snackbar;
import com.google.firebase.messaging.FirebaseMessagingService;
import com.google.firebase.messaging.RemoteMessage;
import com.google.gson.Gson;
import com.sdk.wisetracker.new_dot.open.DOT;

import java.util.Map;

public class FcmService extends FirebaseMessagingService {
  static final String TAG_FCM_TOKEN = "FCM SVC Token";
  static final String TAG_FCM_RCV = "FCM SVC Rcv.Msg.";

  @Override
  public void onNewToken(@NonNull String token) {
    super.onNewToken(token);
    // call Wisetracker API
    DOT.setPushToken(token);
    Log.d(TAG_FCM_TOKEN, "token: " + token);
  }

  @Override
  public void onMessageReceived(@NonNull RemoteMessage remoteMessage) {
    super.onMessageReceived(remoteMessage);

    //
    // 1. SDK 호출하기
    DOT.setPushReceiver(remoteMessage.toIntent());
    Log.d(TAG_FCM_RCV, "remoteMessage: " + remoteMessage);

    //
    // 2. 푸시메시지에서 데이터 추출하기
    Map<String, String> rootDict = remoteMessage.getData();
    String jsonDict = rootDict.get("RW_push_payload_WP");
    Map dict = (new Gson()).fromJson(jsonDict, Map.class);
    if (dict != null) {
      String title = (String) dict.get("RW_push_payload_TT"); // 푸시 메시지 제목
      String body = (String) dict.get("RW_push_payload_BD"); // 푸시 메시지 내용
      String deepLink = (String) dict.get("RW_push_payload_deeplink"); // 푸시 메시지 딥링크
      Log.d(TAG_FCM_RCV, "title: " + title + ", body: " + body + ", deepLink: " + deepLink);

      // 3. 푸시 메시지를 Snackbar로 띄우기 위해 브로드캐스팅하기
      //   : 브로드캐스팅 리시버를 MainActivity에 구현
      Intent intent = new Intent("EVENT_PUSH_FOREGROUND");
      intent.putExtra("RW_push_payload_WP", jsonDict);
      LocalBroadcastManager.getInstance(getApplicationContext()).sendBroadcast(intent);
    } else {
      Log.w(TAG_FCM_RCV, "dictionary was NULL, rootDict: " + rootDict);
    }
  }
}
