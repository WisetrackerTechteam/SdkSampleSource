import React, { useEffect, useState, useRef } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { NavigationService } from '../common';  
import { withNavigationFocus } from 'react-navigation';

// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native';
 
// deeplink 처리
import {Linking} from 'react-native';

const MainScreen = ({navigation}) => {    
 

 	// 앱 실행후 메인 화면 처음 노출 될때, onStartPage 호출. 
 	useEffect(()=>{
 	 	if( navigation.isFocused()){
 	 	 	  if( NativeModules.DotReactBridge != null ) { 
					NativeModules.DotReactBridge.onStartPage();
 	 	 	  }  
 	 	} 

 	 	// 딥링크 추출 리스너 선언 
		Linking.getInitialURL()                         // 최초 실행 시에 Universal link 또는 URL scheme요청이 있었을 때 여기서 찾을 수 있음 
		    .then(value => { 
		    redirectionScreen("getInitialURL", value); 
		});

		Linking.addEventListener('url', (e) => {       // 앱이 실행되어있는 상태에서 요청이 왔을 때 처리하는 이벤트 등록
		    redirectionScreen("addEventListener", e.url);
		}); 

		return () => {
			Linking.remove('url'); 
		};  	

 	},[]); 

 	// 현재 화면의 페이지 정보 설정. 
 	useEffect(()=>{
 	 	if( navigation.isFocused()){
 	 		// 화면이 노출될때 현재 화면에 대한 page_id 설정 
			if( NativeModules.DotReactBridge != null )	{  
				NativeModules.DotReactBridge.logScreen(JSON.stringify({
					page_id : "main.js"
				}));
			} 		
 		} 
	}); 
	
 	// deeplink 처리 함수 
	redirectionScreen = (fromCall, url) => {
		console.log( fromCall, url );
		// 딥링크가 없다면 메인 화면으로 이동 시킴. 		    	
    	if( url == null || url == undefined || url === ""){
    		NavigationService.navigate('MainScreen', {
                screen: 'MainScreen',
                info: 'information'
            });
    	}  
    	else{
    		// 딥링크가 있다면 url 을 parse 하여 이동할 페이지를 지정함. 
    		// 아래의 예시는 상품 상세로 이동하는 처리를 하고 있음.   
			NavigationService.navigate('ProductDetail', {
                screen: 'ProductDetail',
                info: 'information'
            });
    	} 
	};


 	return (
		<View style={styles.container}>
			<Text style={styles.appTitle}>메인 화면을 보고 있습니다.</Text> 

 			<Button title="회원가입 이벤트" 
					style={styles.actionBtn} 
					onPress={()=>{  
						if( NativeModules.DotReactBridge != null )	{ 
							NativeModules.DotReactBridge.logEvent(JSON.stringify({
								event : "w_signup_complete",
								signupTp : "email"
							})); 
						 	alert('회원가입 이벤트 데이터가 서버로 전송되었습니다.');
						}
					}}	
			/> 

			<Button title="로그인 이벤트" 
					style={styles.actionBtn} 
					onPress={()=>{
						if( NativeModules.DotReactBridge != null )	{ 
							NativeModules.DotReactBridge.setUser(JSON.stringify({
								mbr:"Y",
								sx : "male",
								ag : "20-29",
								ut1 : "platinum" 
							})); 
							NativeModules.DotReactBridge.logEvent(JSON.stringify({
								event : "w_login_complete",
								loginTp : "kakao"
							}));
							alert('로그인 이벤트 데이터가 서버로 전송되었습니다.');
						} 
					}}	
			/> 

			<Button title="상품 상세 페이지 이동" 
					style={styles.actionBtn} 
					onPress={()=> NavigationService.navigate('ProductDetail', {
	                    screen: 'ProductDetail',
	                    info: 'information'
	                })}
			/>  

 			<Button title="결제 완료 페이지 이동" 
					style={styles.actionBtn} 
					onPress={()=> NavigationService.navigate('OrderCompleted', {
	                    screen: 'OrderCompleted',
	                    info: 'information'
	                })}
			/>  


 			<Button title="이벤트 페이지 이동" 
					style={styles.actionBtn} 
					onPress={()=> NavigationService.navigate('EventPage', {
	                    screen: 'EventPage',
	                    info: 'information'
	                })}
			/> 

 			<Button title="웹뷰 페이지 이동" 
					style={styles.actionBtn} 
					onPress={()=> NavigationService.navigate('WebviewPage', {
	                    screen: 'WebviewPage',
	                    info: 'information'
	                })}
			/> 

		</View>
	);
};   
export default withNavigationFocus(MainScreen);

