import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/navigator.dart';

class MyRouteObserver extends RouteObserver<PageRoute<dynamic>> {
  

  void _sendScreenView(PageRoute<dynamic> route) {
    var screenName = route.settings.name;
    
    print('screenName onStartPage  $screenName');
    // do something with it, ie. send it to your analytics service collector
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