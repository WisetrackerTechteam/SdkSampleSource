import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/navigator.dart';
import 'package:dot_flutter/dot_flutter.dart';

class MyRouteObserver extends RouteObserver<PageRoute<dynamic>> {
  

  void _sendScreenView(PageRoute<dynamic> route) {
    var screenName = route.settings.name;
     
    // 화면 전환 시점에 onStartPage 함수 호출. 
    // 단, 웹뷰 페이지는 해당 웹뷰에서 웹 페이지를 로딩하는 시점에 onStartPage를 따로 처리하기 때문에, 웹뷰 화면에 대한 Route는 호출 제외. 
    if( screenName != "/webviewScreen") { 
      DOT.onStartPage();
      print('DOT.onStartPage() Called in RouteObserver $screenName');  
    }   
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