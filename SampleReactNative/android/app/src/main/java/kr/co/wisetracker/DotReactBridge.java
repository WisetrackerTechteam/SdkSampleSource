package kr.co.wisetracker;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;

import com.android.installreferrer.api.ReferrerDetails;
import com.facebook.react.bridge.ReactApplicationContext;
import com.facebook.react.bridge.ReactContextBaseJavaModule;
import com.facebook.react.bridge.ReactMethod;
import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;
import com.google.gson.reflect.TypeToken;
import com.sdk.wisetracker.base.open.model.User; 
import com.sdk.wisetracker.new_dot.open.DOT;
import com.sdk.wisetracker.base.tracker.util.ValueOf;

import org.apache.commons.codec.binary.StringUtils;
import org.json.JSONArray;
import org.json.JSONObject;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import javax.annotation.Nonnull;

/**
 * react <-> react android 플러그인 브릿지 클래스
 * react에서 넘어온 데이터를 통해 Natvie SDK 호출
 */
public class DotReactBridge extends ReactContextBaseJavaModule {

    private final String TAG = "DotReactBridge";

    public DotReactBridge(@Nonnull ReactApplicationContext reactContext) {
        super(reactContext);
    }

    @Nonnull
    @Override
    public String getName() {
        return "DotReactBridge";
    }

    @ReactMethod
    public void initialization() {
        try {
            Log.d(TAG, "initialization call");
            DOT.open("react-native");
            DOT.initialization(getReactApplicationContext());
        } catch (Exception e) {
            Log.e(TAG, "initialization error !!", e);
        }
    }

    @ReactMethod
    public void setPushReceiver(Intent intent) {
        try {
            DOT.setPushReceiver(intent);
        } catch (Exception e) {
            Log.e(TAG, "set push receiver error !!", e);
        }
    }

    @ReactMethod
    public void setPushClick(Intent intent) {
        try {
            DOT.setPushClick(getReactApplicationContext(), intent);
        } catch (Exception e) {
            Log.e(TAG, "set push click error !!", e);
        }
    }

    @ReactMethod
    public void setPushToken(String pushToken) {
        try {
            DOT.setPushToken(pushToken);
        } catch (Exception e) {
            Log.e(TAG, "set push token error !!", e);
        }
    }

    @ReactMethod
    public void setDeepLink(Intent intent) {
        try {
            if (intent == null) {
                return;
            }
            DOT.setDeepLink(getReactApplicationContext(), intent);
        } catch (Exception e) {
            Log.e(TAG, "set deep link error !!", e);
        }
    }

    @ReactMethod
    public void setDeepLink(String url) {
        try {
            DOT.setDeepLink(getReactApplicationContext(), url);
        } catch (Exception e) {
            Log.e(TAG, "set deep link error !!", e);
        }
    }

    @ReactMethod
    public void setInstallReferrer(ReferrerDetails referrerDetails) {
        try {
            DOT.setInstallReferrer(referrerDetails);
        } catch (Exception e) {
            Log.e(TAG, "set install referrer error !!", e);
        }
    }

    @ReactMethod
    public void setFacebookReferrer(Bundle bundle) {
        try {
            DOT.setFacebookReferrer(bundle);
        } catch (Exception e) {
            Log.e(TAG, "set facebook referrer error !!", e);
        }
    }


    @ReactMethod
    public void setUser(String json) {
        try {
            if (TextUtils.isEmpty(json)) {
                Log.d(TAG, "user data is null or empty");
                return;
            }
            User user = new Gson().fromJson(json, User.class);
            if (user == null) {
                Log.d(TAG, "user gson converter is null");
                return;
            }
            DOT.setUser(user);
        } catch (Exception e) {
            Log.e(TAG, "set user error !!", e);
        }
    }

    @ReactMethod
    public void setUserLogout() {
        DOT.setUserLogout();
    }

    @ReactMethod
    public void onPlayStart() {
        try {
            DOT.onPlayStart();
        } catch (Exception e) {
            Log.e(TAG, "onPlayStart error !!", e);
        }
    }

    @ReactMethod
    public void onPlayStart(String period) {
        try {
            if (TextUtils.isEmpty(period)) {
                DOT.onPlayStart();
            } else {
                try {
                    DOT.onPlayStart(Integer.valueOf(period));
                } catch (Exception e) {
                    DOT.onPlayStart();
                    Log.e(TAG, "onPlayStart error !!", e);
                }
            }
        } catch (Exception e) {
            Log.e(TAG, "onPlayStart error !!", e);
        }
    }

    @ReactMethod
    public void onPlayStop() {
        try {
            DOT.onPlayStop();
        } catch (Exception e) {
            Log.e(TAG, "onPlayStop error !!", e);
        }
    }

    @ReactMethod
    public void onStartPage() {
        DOT.onStartPage(null);
    }

    @ReactMethod
    public void onStopPage() {
        DOT.onStopPage();
    }

    @ReactMethod
    public void logScreen(String pageJson) {
        try {
            Log.d(TAG, "log screen event");
            if (TextUtils.isEmpty(pageJson)) {
                Log.d(TAG, "page json is null");
                return;
            }
            Log.d(TAG, "raw data : " + pageJson);
            Type type = new TypeToken<Map<String, Object>>() {
            }.getType();
            Map<String, Object> pageMap = new Gson().fromJson(pageJson, type);
            if (pageMap == null) {
                Log.d(TAG, "page map is null");
                return;
            }
            DOT.logScreen(pageMap);
        } catch (Exception e) {
            Log.e(TAG, "log screen error !!", e);
        }
    }

    @ReactMethod
    public void logPurchase(String purchaseJson) {
        try {
            Log.d(TAG, "log purchase event");
            if (TextUtils.isEmpty(purchaseJson)) {
                Log.d(TAG, "purchase json is null");
                return;
            }
            Log.d(TAG, "raw data : " + purchaseJson);
            Type type = new TypeToken<Map<String, Object>>() {
            }.getType();
            Map<String, Object> purchaseMap = new Gson().fromJson(purchaseJson, type);
            if (purchaseMap == null) {
                Log.d(TAG, "purchase map is null");
                return;
            }
            DOT.logPurchase(purchaseMap);
        } catch (Exception e) {
            Log.e(TAG, "log purchase error !!", e);
        }
    }

    @ReactMethod
    public void logEvent(String conversionJson) {
        try {
            Log.d(TAG, "log conversion event");
            if (TextUtils.isEmpty(conversionJson)) {
                Log.d(TAG, "conversion json is null");
                return;
            }
            Log.d(TAG, "raw data : " + conversionJson);
            Type type = new TypeToken<Map<String, Object>>() {
            }.getType();
            Map<String, Object> conversionMap = new Gson().fromJson(conversionJson, type);
            if (conversionMap == null) {
                Log.d(TAG, "conversion map is null");
                return;
            }
            DOT.logEvent(conversionMap);
        } catch (Exception e) {
            Log.e(TAG, "log conversion error !!", e);
        }
    }

    @ReactMethod
    public void logClick(String clickJson) {
        try {
            Log.d(TAG, "log click event");
            if (TextUtils.isEmpty(clickJson)) {
                Log.d(TAG, "click json is null");
                return;
            }
            Log.d(TAG, "raw data : " + clickJson);
            Type type = new TypeToken<Map<String, Object>>() {
            }.getType();
            Map<String, Object> clickMap = new Gson().fromJson(clickJson, type);
            if (clickMap == null) {
                Log.d(TAG, "click map is null");
                return;
            }
            DOT.logClick(clickMap);
        } catch (Exception e) {
            Log.e(TAG, "log click error !!", e);
        }
    }

     

    private Map<String, String> getGroups(String groups) {

        try {

            Type type = new TypeToken<Map<String, String>>() {
            }.getType();
            Map<String, String> groupsMap = new Gson().fromJson(groups, type);
            if (groupsMap == null) {
                return null;
            }
            return groupsMap;

        } catch (Exception e) {
            Log.e(TAG, "get groups error !!", e);
        }

        return null;

    } 

}