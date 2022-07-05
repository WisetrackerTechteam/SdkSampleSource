import React, { useEffect } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { NavigationService } from '../common';

// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native'

const OrderCompleted = ({navigation}) => { 

 	 useEffect(()=>{
 	 	if( navigation.isFocused() ){ 
			// 화면이 노출될때 현재 화면에 대한 page_id 설정 
			if( NativeModules.DotReactBridge != null )	{  
				NativeModules.DotReactBridge.logScreen(JSON.stringify({
					page_id : "purchase.js"
				}));
			}  
 	 	}
 	 }); 

 	 /**
		구매 데이터는 현재 화면이 사용자에게 노출될때, 전송됩니다. 
		따라서, useState, useEffect 등에 의해서 아래의 부분이 반복해서 호출될 수 있으므로, 
		실제 구현된 상황에 따라, 구매 데이터가 1회만 전송될 수 있도록 하는 추가 구현을 하시기 바랍니다.  
 	 **/
 	 
	if( NativeModules.DotReactBridge != null )	{  
		NativeModules.DotReactBridge.logPurchase(JSON.stringify({
			transaction_id : "TR2020111129420",
			currency : "KRW",
			product : {
				product_id : "2007291158",
				product_name : "Leia Pleats Bag Black",
				quantity : 1,
				revenue : 20000 
			}
		})); 		
	} 

	return (
		<View style={styles.container}>
			<Text style={styles.appTitle}>결제 완료 화면을 보고 있습니다. 구매 데이터가 서버로 전송 되었습니다.</Text> 

 			<Button title="메인으로 돌아가기" 
					style={styles.actionBtn} 
					onPress={()=> NavigationService.back()}
			/> 

		</View>
	);
};  
export default  OrderCompleted;

 
