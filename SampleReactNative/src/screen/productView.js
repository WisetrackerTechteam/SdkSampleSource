import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
 // WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native'

const ProductDetail = () => { 

	if( NativeModules.DotReactBridge != null )	{  
		NativeModules.DotReactBridge.logScreen(JSON.stringify({
			page_id : "productView.js"
		}));
	} 

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

		</View>
	);
};  
export default  ProductDetail;