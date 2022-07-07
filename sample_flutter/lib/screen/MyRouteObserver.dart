import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/navigator.dart';
import 'package:dot_sdk/dot_sdk.dart';

class MyRouteObserver extends RouteObserver<PageRoute<dynamic>> {
  

  void _sendScreenView(PageRoute<dynamic> route) {
    var screenName = route.settings.name;
     
    // 화면 전환 시점에 onStartPage 함수 호출.  
    DOT.onStartPage();
    print('DOT.onStartPage() Called  $screenName');
     
  }

  @override
  void didPush(Route<dynamic> route, Route<dynamic>? previousRoute) {
    super.didPush(route, previousRoute);
    if (route is PageRoute) {
      _sendScreenView(route);
    }
  } 

  @override
  void didPop(Route<dynamic> route, Route<dynamic>? previousRoute) {
    super.didPop(route, previousRoute);
    if (previousRoute is PageRoute && route is PageRoute) {
      _sendScreenView(previousRoute);
    }
  }
}