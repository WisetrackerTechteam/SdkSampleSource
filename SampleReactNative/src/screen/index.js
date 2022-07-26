import { createAppContainer, createSwitchNavigator } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';
import MainScreen from './main'; 
import ProductDetail from "./productView";
import OrderCompleted from "./purchase";
import EventPage from "./event";

const AuthStack = createStackNavigator(
    { 
        MainScreen: {screen: MainScreen},
        ProductDetail: {screen: ProductDetail},
        OrderCompleted: {screen: OrderCompleted},
        EventPage: {screen: EventPage}
    },
    {
        initialRouteName: 'MainScreen'
    }
);

// 최상단 네비게이터
const AppNavigator = createSwitchNavigator(
    {
        Auth: AuthStack
    },
    {
        initialRouteName: 'Auth',
    }
);   
export default createAppContainer(AppNavigator);
 