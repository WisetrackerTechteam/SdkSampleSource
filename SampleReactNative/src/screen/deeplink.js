import React, { useEffect, useState, useRef } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { styles } from '../css/css';
import { NavigationService } from '../common';  
import { withNavigationFocus } from 'react-navigation';

// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native';
  
// deeplink 처리
import {Linking, Alert} from 'react-native';

const DeeplinkScreen = ({navigation}) => { 
    
	useEffect(()=>{ 
		Linking.getInitialURL()                         // 최초 실행 시에 Universal link 또는 URL scheme요청이 있었을 때 여기서 찾을 수 있음 
		    .then(value => { 
		    redirectionScreen("getInitialURL", value); 
		});

		Linking.addEventListener('url', (e) => {       // 앱이 실행되어있는 상태에서 요청이 왔을 때 처리하는 이벤트 등록
		    redirectionScreen("addEventListener", e.url);
		});  

	},[]); 

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
	return null;
};   
export default withNavigationFocus(DeeplinkScreen);
