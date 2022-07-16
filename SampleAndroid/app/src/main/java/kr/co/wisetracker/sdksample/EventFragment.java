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

import java.util.HashMap;
import java.util.Map;

import kr.co.wisetracker.sdksample.databinding.FragmentEventBinding;

public class EventFragment extends Fragment {

  private FragmentEventBinding binding;

  //
  // 이벤트 페이지
  public static EventFragment newInstance() {
    return new EventFragment();
  }

  @Override
  public View onCreateView(
      @NonNull LayoutInflater inflater, ViewGroup container,
      Bundle savedInstanceState
  ) {
    binding = FragmentEventBinding.inflate(inflater, container, false);
    return binding.getRoot();
  }

  @Override
  public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    binding.buttonMain.setOnClickListener(view1 ->
        NavHostFragment.findNavController(EventFragment.this)
            .navigate(R.id.action_EventFragment_to_MainFragment));
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

    // 1. 이벤트 조회 화면입니다.
    Map<String, Object> pageMap = new HashMap<>();
    pageMap.put("event", "w_view_event");
    pageMap.put("event_id", "E200905605");
    pageMap.put("event_name", "10월 COUPON PACK");
    DOT.logScreen(pageMap);

    Log.d("DOT", "DOT.onResume() => SDK 호출/이벤트 조회 기록");
  }

}