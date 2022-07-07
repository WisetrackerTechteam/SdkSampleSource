package com.example.sample_flutter

import android.os.Bundle
import androidx.annotation.Nullable
import io.flutter.embedding.android.FlutterActivity
import com.sdk.wisetracker.new_dot.open.DOT;
class MainActivity: FlutterActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState);
        /**
         * Wisetracker SDK init
         * **/
        DOT.initialization(this);

    };

}
