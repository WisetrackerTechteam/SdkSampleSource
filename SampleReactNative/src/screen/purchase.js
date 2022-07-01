import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { NavigationService } from '../common';

const OrderCompleted = () => { 
	return (
		<View style={styles.container}>
			<Text style={styles.appTitle}>결제 완료 화면을 보고 있습니다. 구매 데이터가 서버로 전송 되었습니다.</Text>  
		</View>
	);
};  
export default  OrderCompleted;