import {
    StackNavigator,TouchableHighlight
} from 'react-navigation';


const DrawerNavigation = StackNavigator({
    DrawerStack: {screen: DrawerStack}
},{
    headerMode: 'float',
    navigationOptions: ({navigation}) => ({
        headerStyle:{
            backgroundColor: 'rgb(255, 45, 85)',
            paddingLeft: 10,
            paddingRight: 10
        },
        title: 'Home',
        headerTintColor: 'white',
        headerLeft: <View>
                        <TouchableHighlight onPress={() => {
                            navigation.navigate('DrawerOpener');
                        }}>
                        </TouchableHighlight>
                        <Text>Menu</Text>
                    </View>
    })
}
)