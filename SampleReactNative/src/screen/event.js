import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { NavigationService } from '../common';

const EventPage = () => { 
	return (
		<View style={styles.container}>
			<Text style={styles.appTitle}>이벤트 화면을 보고 있습니다.이벤트 데이터가 서버로 전송 되었습니다.</Text>  
		</View>
	);
};  
export default  EventPage;