import React from 'react';


import Login from './src/Component/Login'
import To_Do_List  from './src/Component/To_Do_List';
import Input_To_Do  from './src/Component/Input_To_Do';
import To_Do_Layout from './src/Component/To_Do_Layout';

import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

const Stack = createStackNavigator();

export default function App() {
  return (
    
    // Navigation using stack

    <NavigationContainer>
      <Stack.Navigator>
      <Stack.Screen name="Login" component={Login} />
      <Stack.Screen name="Create A To-Do" component={Input_To_Do}></Stack.Screen>
      <Stack.Screen name="Your To-Do List" component={To_Do_List} />  
      <Stack.Screen name="Layout" component={To_Do_Layout}></Stack.Screen>
 </Stack.Navigator>
    </NavigationContainer> 
  );
}
