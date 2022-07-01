import { NavigationActions } from 'react-navigation';

// WiseTracker SDK Bridge Module Access
import { NativeModules } from 'react-native'

let _navigator;

function setTopLevelNavigator(navigatorRef) {
    _navigator = navigatorRef;
}

function navigate(routeName, params) {    

    if( NativeModules.DotReactBridge != null )  {  
        NativeModules.DotReactBridge.onStartPage();
    }

    _navigator.dispatch(
        NavigationActions.navigate({
            routeName,
            params,
        })
    ) 
}

function back() {   
    _navigator.dispatch(
        NavigationActions.back()
    );
} 

export default {
    navigate,
    setTopLevelNavigator,
    back,
};