import {DrawerNavigator} from 'react-navigation';

import Main from '../pages/main';
import Screen2 from '../pages/screen2';
import Screen3 from '../pages/screen3';

const DrawerScreen = DrawerNavigator({
    Main: {screen: Main},
    Screen2: {screen: Screen2},
    Screen3: {screen: Screen3}
},{
    headerMode: 'none',
})

export default DrawerScreen;