import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { NavigationService } from '../common';

// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native'

const OrderCompleted = () => { 


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
		</View>
	);
};  
export default  OrderCompleted;

 
