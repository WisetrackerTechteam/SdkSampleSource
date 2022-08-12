import 'package:flutter/material.dart';
import 'package:logger/logger.dart';
import 'package:sample_flutter/MainApp.dart';

final RouteObserver<PageRoute> routeObserver = RouteObserver<PageRoute>();
var logger = Logger();

void main() {
  runApp(const NavigationModule());
}

// NavigationService
class NavigationModule extends StatelessWidget {
  const NavigationModule({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const MainApp();
  }
}
