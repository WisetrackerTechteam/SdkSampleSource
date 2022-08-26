import 'dart:async';

import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:get/get.dart';
import 'package:get/route_manager.dart';
import 'package:sample_flutter/main.dart';
import 'package:sample_flutter/screen/MyRouteObserver.dart';
import 'package:sample_flutter/screen/event.dart';
import 'package:sample_flutter/screen/mainScreen.dart';
import 'package:sample_flutter/screen/productScreen.dart';
import 'package:sample_flutter/screen/purchase.dart';
import 'package:sample_flutter/screen/webviewScreen.dart';
import 'package:uni_links/uni_links.dart';

//
// Start : Deep link
bool _initialURILinkHandled = false; // 초기화를 한번만하기 위해 초기화 했는지 여부를 저장한 변수
// End : Deep link
//

class MainApp extends StatefulWidget {
  const MainApp({Key? key}) : super(key: key);

  @override
  State<MainApp> createState() => _MainAppState();
}

class _MainAppState extends State<MainApp> {
  //
  // Start : Deep link
  StreamSubscription? _streamSubscription; // 앱이 백그라운드 상태일 때 딥링크 전달에 대한 리스너 인스턴스

  @override
  void initState() {
    super.initState();
    _initURIHandler();
    _incomingLinkHandler();
  }

  // 앱이 최초 실행될 때 실행될 함수
  // 앱이 백그라운드 상태일 때는 리스너에서 참조
  Future<void> _initURIHandler() async {
    if (!_initialURILinkHandled) {
      _initialURILinkHandled = true;
      try {
        final uri = await getInitialUri();
        // URL이 정상적으로 전달되지 않은 경우 warning
        // URL이 null 인 경우도 있음에 주의
        if (uri != null) {
          logger.d("DeepLink 초기 URI 받았음: ${uri.path}");
          if (!mounted) return;
          if (uri.path.contains("/productDetail")) {
            Get.toNamed("/productDetail");
          } else if (uri.path.contains("/event")) {
            Get.toNamed("/event");
          } else if (uri.path.contains("/purchase")) {
            Get.toNamed("/purchase");
          } else {
            logger.w("알 수 없는 URI: $uri");
          }
        } else {
          logger.d("DeepLink 초기 URI 받았음: Null");
        }
      } on PlatformException {
        // URI 읽어오는 과정에서 예외상황 발생
        logger.w("DeepLink 초기 URI를 받아오는 과정에서 예외상황 발생");
      } on FormatException catch (err) {
        if (!mounted) return;
        logger.w('DeepLink 초기 URI 받았음: 포맷이 맞지 않는 URI');
      }
    }
  }

  // 백그라운드 상태에서 URI 받아오는 핸들러 구현
  void _incomingLinkHandler() {
    if (!kIsWeb) {
      // 웹이 아닌 앱인 경우에만 작동
      // URL이 전달된 경우에 대한 리스너 구현
      _streamSubscription = uriLinkStream.listen((Uri? uri) {
        if (!mounted) return;
        logger.d('DeepLink 백그라운드 상태에서 URI 받았음: $uri');
        if (uri != null) {
          if (uri.path.contains("/productDetail")) {
            Get.toNamed("/productDetail");
          } else if (uri.path.contains("/event")) {
            Get.toNamed("/event");
          } else if (uri.path.contains("/purchase")) {
            Get.toNamed("/purchase");
          } else {
            logger.w("알 수 없는 URI: $uri");
          }
        }
      }, onError: (Object err) {
        // 처리중 오류 발생시
        if (!mounted) return;
        logger.d('DeepLink URI 처리 오류: $err');
      });
    }
  }

  @override
  void dispose() {
    _streamSubscription
        ?.cancel(); // 비동기 DeepLink 전달을 리스닝하는데 이용된 자원을 돌려주기 위해 cancel()
    super.dispose();
  }

  // End : Deep link
  //

  @override
  Widget build(BuildContext context) {
    return GetMaterialApp(
      navigatorObservers: [MyRouteObserver()],
      routes: {
        '/productDetail': (context) => ProductDetailScreen(),
        '/event': (context) => EventScreen(),
        '/purchase': (context) => PurchaseScreen(),
        '/webviewScreen': (context) => WebviewScreen()
      },
      home: MainScreen(),
    );
  }
}
