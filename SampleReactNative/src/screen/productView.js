import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
 

const ProductDetail = () => { 
	return (
		<View style={styles.container}>
			<Text style={styles.appTitle}>상품 상세 화면을 보고 있습니다.상품 데이터가 서버로 전송 되었습니다.</Text> 

 			<Button title="장바구니 담기 이벤트" 
					style={styles.actionBtn} 
					onPress={()=>{
						 alert('장바구니 담기 이벤트 데이터가 서버로 전송되었습니다.');
					}}	
			/>

		</View>
	);
};  
export default  ProductDetail;