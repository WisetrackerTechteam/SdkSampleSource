package kr.co.wisetracker;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

import com.sdk.wisetracker.new_dot.open.DOT;

/**
 * 고객사 react 프로젝트에서 딥링크 이용시 편리하게 Native SDK 호출이 가능하도록 하기 위해 제공하는 Activity
 * 고객사에서 직접 딥링크로 오픈되는 Activity를 생성후 그 곳에서 SDK 태깅 해도 무방 (해당 Activity는 고객사 개발 편의를 위해 제공)
 */
public class DeepLinkActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setSDK(getIntent());
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        setSDK(intent);
    }

    private void setSDK(Intent intent) {
        try {
            Log.i("[wisetracker]", "set sdk by deep link!!");
            if (intent == null || intent.getData() == null) {
                Log.i("[wisetracker]", "intent is null !!");
                return;
            }
            DOT.setDeepLink(getApplicationContext(), getIntent());
            moveToMainActivity();
        } catch (Exception e) {
            Log.e("[wisetracker]", "set sdk error !!", e);
        }
    }

    private void moveToMainActivity() {
        try {
            Intent intent = getPackageManager().getLaunchIntentForPackage(getPackageName());
            intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            startActivity(intent);
            finish();
        } catch (Exception e) {
            Log.i("[wisetracker]", "move to main activity error !!", e);
        }
    }

}