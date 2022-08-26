import React, { useEffect, useState, useRef } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { NavigationService } from '../common';
import {WebView} from 'react-native-webview';


// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native'

const WebviewPage = ({navigation}) => { 
	
	const BASE_URL = 'http://192.168.1.152/mrcm.html';

	const webviewRef = useRef(); 
	return ( 
			<WebView source={{uri: BASE_URL}}
			         ref={webviewRef}
			         onLoadStart={(syntheticEvent)=>{ 
			         	if( NativeModules.DotReactBridge != null )	{  
			         		/**
 								웹 페이지가 로딩 시작될때, onStartPage 호출 
			         		**/
			         		NativeModules.DotReactBridge.onStartPage(); 
						} 
			         }} 
			         /***
						웹뷰에서 로딩되는 웹 페이지에 적용된 분석 코드는 다음과 같은 형태로 작성 
						window.ReactNativeWebView.postMessage(JSON.stringify({
							method : "logEvent",
							data: {
								event : "webview_event_fire", 
							} 
						})); 
						위의 함수 호출에 의한 메시지는 onMessage에서 수신 받게 됨.  
						수신받은 데이터에서, method 이름에 따라 다음과 같이  NativeModules.DotReactBridge 객체로 데이터를 전달하도록 구현.  
			         */
			         onMessage={(event) => { 
			         	if( event.nativeEvent.data !== undefined ){
			         		// 데이터 수신은 string으로 전달되므로 json으로 변환 
			         		let webData = JSON.parse(event.nativeEvent.data);
			         		if( webData.method ){
								switch(webData.method){
									// logEvent call 
									case "logEvent" : 
									NativeModules.DotReactBridge.logEvent(JSON.stringify(webData.data)); 	
									break;
									
									// logScreen call 
									case "logScreen" : 
									NativeModules.DotReactBridge.logScreen(JSON.stringify(webData.data));
									break;

									// logPurchase	
									case "logPurchase" : 
									NativeModules.DotReactBridge.logPurchase(JSON.stringify(webData.data));
									break;
								} 
			         		}  
			         	} 
			         }}
			    />  	
	);

};  
export default  WebviewPage;