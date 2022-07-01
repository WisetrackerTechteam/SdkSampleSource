import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { NavigationService } from '../common'; 
import { useIsFocused } from '@react-navigation/native';

// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native';
 
const MainScreen = () => {   
 
	if( NativeModules.DotReactBridge != null )	{  
		NativeModules.DotReactBridge.logScreen(JSON.stringify({
			page_id : "main.js"
		}));
	} 

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
							NativeModules.DotReactBridge.setUser({
								sx : "male",
								ag : "20-29",
								ut1 : "platinum" 
							}); 
							NativeModules.DotReactBridge.logEvent(JSON.stringify({
								event : "w_login_complete",
								signupTp : "kakao"
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

		</View>
	);
};  
export default  MainScreen;