import 'package:flutter/material.dart';
import 'showDialogFunc.dart';
import 'package:dot_flutter/dot_flutter.dart';
import 'package:webview_flutter/webview_flutter.dart';
import 'dart:convert';



// 이벤트  화면 
class WebviewScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) { 
    return WebView(
      initialUrl: 'http://192.168.1.152/mrcm.html',
      javascriptMode: JavascriptMode.unrestricted, 

      /**
       * Web To Flutter 데이터 전송 채널 등록 
       * 웹 페이지에서는 아래의 코드와 같이 DotFlutterDataBridge Javascript 채널을 통해서 데이터를 flutter 로 전송하게됨. 
       * DotFlutterDataBridge.postMessage(JSON.stringify({
       *       method : "logEvent",
       *       data: {
       *               event : "webview_event_fire",
       *       }
       * }));
       * 
       * 전송된 메시지는 아래의 onMessageReceived 함수로 전달되며, 
       * 전달된 데이터를 json parse 하여 native 모듈에 각 함수로 전달될 수 있도록 구현.  
       ***/         
      javascriptChannels: Set.from([ 
              JavascriptChannel( 
              name: "DotFlutterDataBridge", 
              onMessageReceived: (JavascriptMessage result) {  

                // 데이터 수신은 string으로 전달되므로 json으로 변환 
                Map<String, dynamic> webData = jsonDecode(result.message);
                if( webData['method'] != null  ){ 
                  
                  switch(webData['method']){

                    // setUser call 
                    case "setUser":
                    DOT.setUser(webData['data']); 
                    break;  

                    // logEvent call 
                    case "logEvent" : 
                    DOT.logEvent(webData['data']);  
                    break;
                    
                    // logScreen call 
                    case "logScreen" : 
                    DOT.logScreen(webData['data']);
                    break;

                    // logPurchase  
                    case "logPurchase" : 
                    DOT.logPurchase(webData['data']);
                    break;
                  } 

                } 

              }),  
      ]),  

      /**
       * 웹페이지 로딩이 시작될때, onStartPage 호출.  
       ***/   
      onPageStarted:(String url){
      
         DOT.onStartPage();
         print('DOT.onStartPage() Called  in Webview : $url'); 
      } 
    ); 




  }
} 