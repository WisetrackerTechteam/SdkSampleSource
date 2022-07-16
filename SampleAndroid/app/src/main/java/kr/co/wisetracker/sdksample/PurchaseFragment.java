package kr.co.wisetracker.sdksample;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.sdk.wisetracker.new_dot.open.DOT;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.wisetracker.sdksample.databinding.FragmentPurchaseBinding;

public class PurchaseFragment extends Fragment {
  private FragmentPurchaseBinding binding;

  public PurchaseFragment() {
    // Required empty public constructor
  }

  public static PurchaseFragment newInstance() {
    return new PurchaseFragment();
  }

  @Override
  public View onCreateView(
      @NonNull LayoutInflater inflater,
      ViewGroup container,
      Bundle savedInstanceState
  ) {
    binding = FragmentPurchaseBinding.inflate(inflater, container, false);
    return binding.getRoot();
  }

  @Override
  public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    binding.buttonMain.setOnClickListener(view1 ->
        NavHostFragment.findNavController(PurchaseFragment.this)
            .navigate(R.id.action_PurchaseFragment_to_MainFragment));
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

    // 1. 상품 구매 완료
    // 상품구매 완료 화면에 삽입하십시오
    Map<String, Object> purchaseMap = new HashMap<>();
    purchaseMap.put("transaction_id", "TR2020111129421");
    purchaseMap.put("currency", "KRW");

    Map<String, Object> productMap1 = new HashMap<>();
    productMap1.put("product_id", "2007291158");
    productMap1.put("product_name", "Leia Pleats Bag Black");
    productMap1.put("quantity", 2);
    productMap1.put("revenue", 566200);

    Map<String, Object> productMap2 = new HashMap<>();
    productMap2.put("product_id", "2005268849");
    productMap2.put("product_name", "페이 스몰 숄더백 (FAYE)");
    productMap2.put("quantity", 1);
    productMap2.put("revenue", 1323000);

    List<Map<String, Object>> productList = new ArrayList<>();
    productList.add(productMap1);
    productList.add(productMap2);

    purchaseMap.put("product", productList);

    DOT.logPurchase(purchaseMap);

    Log.d("DOT", "DOT.onResume() => SDK 호출/상품상세 정보 기록");
  }
}