package kr.co.wisetracker.sdksample;

import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import com.sdk.wisetracker.base.tracker.common.log.WiseLog;
import com.sdk.wisetracker.new_dot.open.DOT;

import kr.co.wisetracker.sdksample.databinding.FragmentWebviewBinding;

public class WebviewFragment extends Fragment {

  private FragmentWebviewBinding binding;

  private WebView webView;

  public static WebviewFragment newInstance() {
    return new WebviewFragment();
  }

  @Override
  public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
    binding = FragmentWebviewBinding.inflate(inflater, container, false);
    return binding.getRoot();
  }

  @Override
  public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    webView = binding.webviewThird;

    // 1. WebView 를 위한 SDK 세팅을 여기서 호출
    setWebview();
  }

  @Override
  public void onDestroyView() {
    super.onDestroyView();
    binding = null;
  }

  // 2. WebView 를 위한 SDK 세팅
  private void setWebview() {
    webView.setWebViewClient(new WebViewClient() {
      @Override
      public void onPageStarted(WebView view, String url, Bitmap favicon) {
        super.onPageStarted(view, url, favicon);

        // 1.1. document 에 DOT 객체 주입.
        WiseLog.d("onPageStarted() URL: " + url);
        DOT.injectSdkToHtmlDocument(view);
      }

      @Override
      public void onPageCommitVisible(WebView view, String url) {
        super.onPageCommitVisible(view, url);

        // 1.2. document 에 DOT 객체 주입.
        WiseLog.d("onPageCommitVisible() URL: $url");
        DOT.injectJavascriptWithDomSearch(view, url, false);
      }

      @Override
      public void onPageFinished(WebView view, String url) {
        super.onPageFinished(view, url);

        // 1.3. document 에 DOT 객체 주입.
        WiseLog.d("onPageFinished() URL: $url");
        DOT.injectJavascriptWithDomSearch(view, url, true);
      }

    }); // E: WebViewClient()

    // 크롬 클라이언트 설정
    webView.setWebChromeClient(new WebChromeClient()); // E: WebChromeClient()

    webView.getSettings().setUseWideViewPort(true);
    webView.getSettings().setLoadWithOverviewMode(true);
    webView.getSettings().setJavaScriptEnabled(true);
    webView.getSettings().setJavaScriptCanOpenWindowsAutomatically(true);
    webView.getSettings().setBuiltInZoomControls(true);
    webView.getSettings().setSupportZoom(false);
    webView.getSettings().setAllowContentAccess(true);
    webView.getSettings().setDomStorageEnabled(true);
    webView.getSettings().setTextZoom(100);
    webView.getSettings().setCacheMode(WebSettings.LOAD_NO_CACHE);

    webView.getSettings().setAllowFileAccess(true);

    // chrome://inspect 사용을 위해서 개발 환경에서 설정 , 배포시는 삭제
    WebView.setWebContentsDebuggingEnabled(true);

    webView.loadUrl("file:///android_asset/www/main.html"); // 로컬 자원에서 HTML 읽어오기

    // 2. SDK 호출
    DOT.setWebView(webView);
  }

}