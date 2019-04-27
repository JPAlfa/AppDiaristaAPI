import { createAppContainer, createStackNavigator } from 'react-navigation';

import Main from './pages/main';
import Products from './pages/products';
import ProductAdd from './pages/productAdd';

const AppNavigator = createStackNavigator({
	Main,
	Products,
	ProductAdd
}, {
	navigationOptions: {
		headerStyle: {
			backgroundColor: "#FFF"			
		},
		headerTintColor: "#FFF"
	},
},
);

const AppContainer = createAppContainer(AppNavigator);

export default AppContainer;