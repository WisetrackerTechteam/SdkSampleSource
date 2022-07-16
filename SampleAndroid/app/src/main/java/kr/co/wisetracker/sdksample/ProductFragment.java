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

import kr.co.wisetracker.sdksample.databinding.FragmentProductBinding;

public class ProductFragment extends Fragment {

  private FragmentProductBinding binding;

  public static ProductFragment newInstance() {
    return new ProductFragment();
  }

  @Override
  public View onCreateView(
      @NonNull LayoutInflater inflater, ViewGroup container,
      Bundle savedInstanceState
  ) {
    binding = FragmentProductBinding.inflate(inflater, container, false);
    return binding.getRoot();
  }

  @Override
  public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    // 1. 장바구니 담기 이벤트 처리
    binding.buttonCart.setOnClickListener(view1 -> {
      Map<String, Object> eventMap = new HashMap<>();
      eventMap.put("event", "w_add_to_cart"); // 장바구니 담기 이벤트 설정

      // 1.1. 상품 설정
      Map<String, Object> productMap = new HashMap<>();
      productMap.put("product_id", "YOHLIAMYAROOH"); // 상품 ID
      productMap.put("product_name", "멋진 백"); // 상품명
      productMap.put("quantity", 2); // 상품 수량

      eventMap.put("product", productMap); // 상품을 이벤트에 담기

      // 1.2. 이벤트 저장 및 전송
      DOT.logEvent(eventMap);

      Snackbar.make(view, "장바구니 담기가 처리되었습니다.", Snackbar.LENGTH_LONG)
          .setAction("Action", null).show();
    });

    binding.buttonMain.setOnClickListener(view1 ->
        NavHostFragment.findNavController(ProductFragment.this)
            .navigate(R.id.action_ProductFragment_to_MainFragment));
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

    // 2. 상품 상세 페이지 정보 저장 및 전송
    Map<String, Object> pageMap = new HashMap<>();
    pageMap.put("event", "w_view_product");
    Map<String, Object> productMap = new HashMap<>();
    productMap.put("product_id", "YOHLIAMYAROOH");
    productMap.put("product_name", "멋진 백");
    pageMap.put("product", productMap);
    DOT.logScreen(pageMap);

    Log.d("DOT", "DOT.onResume() => SDK 호출/상품상세 정보 기록");
  }

}