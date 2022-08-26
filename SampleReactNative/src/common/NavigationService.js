import { NavigationActions } from 'react-navigation';
// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native';

let _navigator; 
function setTopLevelNavigator(navigatorRef) {
    _navigator = navigatorRef;  
}

function navigate(routeName, params) {   

    // productView, event, purchase 화면으로 이동을 시작할때, onStartPage

    if( NativeModules.DotReactBridge != null ) { 
            /**
             * 웹뷰는 자체적으로 page 가 로딩이 시작되는 시점에 onStartPage를 따로 호출해야 하기 때문에 제외. 
            **/
            if( routeName !== "WebviewPage"){
                NativeModules.DotReactBridge.onStartPage();    
            } 
    }

    _navigator.dispatch( 
        NavigationActions.navigate({
            routeName,
            params,
        })
    ) 
}

function back() {    
    // productView, event, purchase 화면에서 메인 화면으로 되돌아 갈때, onStartPage 
    if( NativeModules.DotReactBridge != null ) { 
        NativeModules.DotReactBridge.onStartPage();
    }

    _navigator.dispatch(
       NavigationActions.back() 
    );
} 

export default {
    navigate,
    setTopLevelNavigator,
    back,
};