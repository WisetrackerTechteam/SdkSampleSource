package kr.co.wisetracker.sdksample;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.google.android.material.snackbar.Snackbar;
import com.sdk.wisetracker.base.open.model.User;
import com.sdk.wisetracker.new_dot.open.DOT;

import java.util.HashMap;
import java.util.Map;

import kr.co.wisetracker.sdksample.databinding.FragmentMainBinding;

public class MainFragment extends Fragment {

  private FragmentMainBinding binding;

  public static MainFragment newInstance() {
    return new MainFragment();
  }

  @Override
  public View onCreateView(
      @NonNull LayoutInflater inflater, ViewGroup container,
      Bundle savedInstanceState
  ) {

    binding = FragmentMainBinding.inflate(inflater, container, false);
    return binding.getRoot();

  }

  @Override
  public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    //
    // 1. 회원가입 이벤트 처리
    binding.buttonSignup.setOnClickListener(view1 -> {
      Map<String, Object> eventMap = new HashMap<>();
      eventMap.put("event", "w_signup_complete"); // 이벤트 유형을 회원가입 완료로 설정
      eventMap.put("signupTp", "email"); // 회원가입 유형을 이메일로 설정
      DOT.logEvent(eventMap); // 이벤트 저장 및 전송

      Snackbar.make(view, "회원가입이 처리되었습니다.", Snackbar.LENGTH_LONG)
          .setAction("Action", null).show();
    });

    //
    // 2. 로그인 이벤트 처리
    binding.buttonLogin.setOnClickListener(view1 -> {
      User user = new User.Builder()
          // 유저의 정보를 시스템으로부터 읽어와서 세팅합니다.
          .setGender("male") // 성별
          .setAge("14-23") // 연령대
          .setAttr1("platinum") // 사용자 정의 필드 : 여기서는 고객등급으로 가정했어요.
          .build();
      DOT.setUser(user); // 유저 정보 설정

      Map<String, Object> eventMap = new HashMap<>();
      eventMap.put("event", "w_login_complete");
      eventMap.put("loginTp", "kakao");
      DOT.logEvent(eventMap); // 이벤트 저장 및 전송

      Snackbar.make(view, "로그인이 처리되었습니다.", Snackbar.LENGTH_LONG)
          .setAction("Action", null).show();
    });

    // 3. 상품 상세 페이지
    binding.buttonProduct.setOnClickListener(view1 ->
        NavHostFragment.findNavController(MainFragment.this)
            .navigate(R.id.action_MainFragment_to_ProductFragment));

    // 4. 결제 완료 페이지
    binding.buttonPurchase.setOnClickListener(view1 ->
        NavHostFragment.findNavController(MainFragment.this)
            .navigate(R.id.action_MainFragment_to_PurchaseFragment));

    // 5. 이벤트 페이지
    binding.buttonEvent.setOnClickListener(view1 ->
        NavHostFragment.findNavController(MainFragment.this)
            .navigate(R.id.action_MainFragment_to_EventFragment));

    // 6. 웹뷰 페이지
    binding.buttonWebview.setOnClickListener(view1 ->
        NavHostFragment.findNavController(MainFragment.this)
            .navigate(R.id.action_MainFragment_to_WebviewFragment));
  }

  @Override
  public void onDestroyView() {
    super.onDestroyView();
    binding = null;
  }

  @Override
  public void onResume() {
    super.onResume();

    // 0. SDK 호출 (일반적인 페이지 기록과 이전 페이지 히스토리 전송 후 삭제)
    DOT.onStartPage(getContext());
    Log.d("DOT", "Call onStartPage()");
  }
}