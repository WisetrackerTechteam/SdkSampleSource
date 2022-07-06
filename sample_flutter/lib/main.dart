import 'package:flutter/material.dart';
import 'screen/mainScreen.dart';
import 'screen/productScreen.dart';
import 'screen/event.dart';
import 'screen/purchase.dart';
import 'dart:developer';
 
final RouteObserver<ModalRoute<void>> routeObserver = RouteObserver<ModalRoute<void>>();
void main() {
  runApp(NavigationModule());
}

// NavigationService 
class NavigationModule extends StatelessWidget {
  @override
  Widget build(BuildContext context) { 
    return MaterialApp(
      home : MainScreen(),
      routes: {
        '/': (context) => MainScreen(),
        '/productDetail': (context) => ProductDetailScreen(),
        '/event': (context) => EventScreen(),
        '/purchase': (context) => PurchaseScreen() 
      },
      navigatorObservers: <RouteObserver<ModalRoute<void>>>[ routeObserver ],
    );
  }
}


class RouteAwareWidget extends StatefulWidget {
  State<RouteAwareWidget> createState() => RouteAwareWidgetState();
}

// Implement RouteAware in a widget's state and subscribe it to the RouteObserver.
class RouteAwareWidgetState extends State<RouteAwareWidget> with RouteAware {

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    routeObserver.subscribe(this, ModalRoute.of(context));
  }

  @override
  void dispose() {
    routeObserver.unsubscribe(this);
    super.dispose();
  }

  @override
  void didPush() {
    // Route was pushed onto navigator and is now topmost route.
  }

  @override
  void didPopNext() {
    // Covering route was popped off the navigator.
  }

  @override
  Widget build(BuildContext context) => Container();

}
