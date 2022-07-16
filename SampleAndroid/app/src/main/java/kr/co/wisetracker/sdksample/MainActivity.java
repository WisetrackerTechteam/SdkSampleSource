package kr.co.wisetracker.sdksample;

import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.localbroadcastmanager.content.LocalBroadcastManager;
import androidx.navigation.NavController;
import androidx.navigation.NavDeepLinkBuilder;
import androidx.navigation.NavDestination;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import com.google.android.material.snackbar.Snackbar;
import com.google.firebase.messaging.FirebaseMessaging;
import com.google.gson.Gson;
import com.sdk.wisetracker.new_dot.open.DOT;

import java.util.Map;

import kr.co.wisetracker.sdksample.databinding.ActivityMainBinding;

public class MainActivity extends AppCompatActivity {

  private AppBarConfiguration appBarConfiguration;

  static final String TAG_MAIN = "MainActivity";
  static final String TAG_FCM_TOKEN = "FCM Token";
  static final String TAG_FCM_CLICK = "FCM Click";
  static final String TAG_FCM_RCV = "FCM Rcv.Msg.";

  // 푸시알림을 받는 서비스에서 브로드캐스팅한 이벤트를 받을 리시버 설정
  private BroadcastReceiver mMessageReceiver = null;

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);

    //
    // 1. Wisetracker SDK 호출
    Log.d(TAG_MAIN, "DOT initializing...");
    DOT.initialization(this);
    Log.d(TAG_MAIN, "DOT initialized.");

    ActivityMainBinding binding = ActivityMainBinding.inflate(getLayoutInflater());
    setContentView(binding.getRoot());

    setSupportActionBar(binding.toolbar);

    NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main);
    appBarConfiguration = new AppBarConfiguration.Builder(navController.getGraph()).build();
    NavigationUI.setupActionBarWithNavController(this, navController, appBarConfiguration);

    //
    // 3. FCM 의 Push 토큰 정보 SDK 에 전달
    FirebaseMessaging.getInstance().getToken()
        .addOnCompleteListener(task -> {
          if (!task.isSuccessful()) {
            Log.w(TAG_MAIN, "Fetching FCM registration token failed", task.getException());
            return;
          }

          // Get new FCM registration token
          String token = task.getResult();

          // 3.1. SDK 에 전달
          DOT.setPushToken(token);
          Log.d(TAG_FCM_TOKEN, "token: " + token);
        });

    //
    // 4. 푸시 메시지를 클릭할 때의 처리
    Intent intent = getIntent();
    // 4.1. 푸시 클릭 데이터 처리
    DOT.setPushClick(this, intent);
    Log.d(TAG_FCM_CLICK, "DOT setPushClick()");
    // 4.2. 푸시 클릭 데이터 해석 및 후처리
    if (intent != null) {
      Bundle bundle = intent.getExtras();
      if (bundle != null) {
        Map dict = (new Gson()).fromJson(bundle.getString("RW_push_payload_WP"), Map.class);
        if (dict != null) {
          String title = (String) dict.get("RW_push_payload_TT"); // 푸시 메시지 제목
          String body = (String) dict.get("RW_push_payload_BD"); // 푸시 메시지 내용
          String deepLink = (String) dict.get("RW_push_payload_deeplink"); // 푸시 메시지 딥링크
          Log.d(TAG_FCM_RCV, "title: " + title + ", body: " + body + ", deepLink: " + deepLink);

          // 4.3. 푸시 클릭 데이터로 전달된 딥링크 처리
          // 샘플앱에서는 분기할 수 있는 화면이 main 을 포함하여 모두 5개입니다.
          if (deepLink != null && !deepLink.isEmpty()) {
            switch (deepLink) {
              case "product":
                navController.navigate(R.id.action_MainFragment_to_ProductFragment);
                break;
              case "purchase":
                navController.navigate(R.id.action_MainFragment_to_PurchaseFragment);
                break;
              case "event":
                navController.navigate(R.id.action_MainFragment_to_EventFragment);
                break;
              case "webview":
                navController.navigate(R.id.action_MainFragment_to_WebviewFragment);
                break;
              default: // 이 구조에서 main 은 할게 없어요.
                break;
            }
            Log.d(TAG_FCM_CLICK, "Fragment");
            // 4.3.2. 화면 분기 처리
          }

        } else {
          Log.w(TAG_FCM_RCV, "dictionary was NULL, intent.getData(): " + intent.getData() + ", intent.getExtras(): " + intent.getExtras());
        }
      } else {
        Log.w(TAG_FCM_RCV, "bundle was NULL");
      }
    } else {
      Log.w(TAG_FCM_RCV, "intent was NULL");
    }

    //
    // 5. 앱이 Foreground 상태일 때 푸시 알림을 서비스에서 받아 브로드캐스팅하면 받을 리시버 설정
    mMessageReceiver = new BroadcastReceiver() {
      @Override
      public void onReceive(Context context, Intent intent) {
        // 5.1. 서비스로 부터 받은 푸시 알림을 이용하기
        Bundle bundle = intent.getExtras();
        if (bundle != null) {
          Map dict = (new Gson()).fromJson(bundle.getString("RW_push_payload_WP"), Map.class);
          if (dict != null) {
            String title = (String) dict.get("RW_push_payload_TT"); // 푸시 메시지 제목
            String body = (String) dict.get("RW_push_payload_BD"); // 푸시 메시지 내용
            String deepLink = (String) dict.get("RW_push_payload_deeplink"); // 푸시 메시지 딥링크
            Log.d(TAG_FCM_RCV, "from BroadcastReceiver > title: " + title + ", body: " + body + ", deepLink: " + deepLink);
          }
        }
      }
    }; // E: BroadcastReceiver()
  }

  @Override
  public boolean onCreateOptionsMenu(@NonNull Menu menu) {
    // Inflate the menu; this adds items to the action bar if it is present.
    getMenuInflater().inflate(R.menu.menu_main, menu);
    return true;
  }

  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    // Handle action bar item clicks here. The action bar will
    // automatically handle clicks on the Home/Up button, so long
    // as you specify a parent activity in AndroidManifest.xml.
    int id = item.getItemId();

    //noinspection SimplifiableIfStatement
    if (id == R.id.action_settings) {
      return true;
    }

    return super.onOptionsItemSelected(item);
  }

  @Override
  public boolean onSupportNavigateUp() {
    NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main);
    return NavigationUI.navigateUp(navController, appBarConfiguration)
        || super.onSupportNavigateUp();
  }

  @Override
  public void onNewIntent(Intent intent) {
    super.onNewIntent(intent);
    // 3.2. 푸시 메시지를 클릭할 때의 처리
    DOT.setPushClick(this, intent);
    Log.d(TAG_FCM_CLICK, "DOT setPushClick() > intent: " + intent);
  }

  @Override
  public void onResume() {
    super.onResume();

    //
    // 5.2. 푸시메시지를 전달받을 브로드캐스팅 리시버 등록 (인텐트 필터 이용)
    LocalBroadcastManager.getInstance(this).registerReceiver(mMessageReceiver, new IntentFilter("EVENT_PUSH_FOREGROUND"));
  }

  @Override
  public void onDestroy() {
    super.onDestroy();
  }
}