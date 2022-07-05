import React, { useEffect } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { withNavigationFocus } from 'react-navigation';
import { NavigationService } from '../common';  

 // WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native'

const ProductDetail = ({navigation}) => { 

 	 useEffect(()=>{
 	 	if( navigation.isFocused() ){ 
			// 화면이 노출될때 현재 화면에 대한 page_id 설정 
			if( NativeModules.DotReactBridge != null )	{  
				NativeModules.DotReactBridge.logScreen(JSON.stringify({
					page_id : "productView.js"
				}));
			}  
 	 	}
 	 }); 
 	 
	return (
		<View style={styles.container}>
			<Text style={styles.appTitle}>상품 상세 화면을 보고 있습니다.상품 데이터가 서버로 전송 되었습니다.</Text> 
 			<Button title="장바구니 담기 이벤트" 
					style={styles.actionBtn} 
					onPress={()=>{
						if( NativeModules.DotReactBridge != null )	{ 
							NativeModules.DotReactBridge.logEvent(JSON.stringify({
								event : "w_add_to_cart",
								product : {
									product_id : "2007291158",
									product_name : "Leia Pleats Bag Black",
									quantity : 2 
								}
							})); 						 
							alert('장바구니 담기 이벤트 데이터가 서버로 전송되었습니다.');
						}
					}}	
			/>

 			<Button title="메인으로 돌아가기" 
					style={styles.actionBtn} 
					onPress={()=> NavigationService.back()}
			/> 

		</View>
	);
};  
export default  ProductDetail;