import 'package:flutter/material.dart';
import 'screen/mainScreen.dart';
import 'screen/productScreen.dart';
import 'screen/event.dart';
import 'screen/purchase.dart';
import 'screen/RouteHelper.dart';
import 'screen/MyRouteObserver.dart';
import 'dart:developer';

final RouteObserver<PageRoute> routeObserver = RouteObserver<PageRoute>();

  
void main() {
  runApp(NavigationModule());
}

// NavigationService 
class NavigationModule extends StatelessWidget {
  @override
  Widget build(BuildContext context) { 
    return MaterialApp( 
      navigatorObservers: [MyRouteObserver()],
      // initialRoute: '/',
      routes: {
        // '/': (context) => const MainScreen(),
        '/productDetail': (context) => ProductDetailScreen(),
        '/event': (context) =>  EventScreen(),
        '/purchase': (context) =>  PurchaseScreen() 
      }, 
      home: MainScreen(),
    );
  }
}
 




