import React, { useState,useEffect } from "react"

import { Text, View,TouchableOpacity,StyleSheet, AsyncStorage,FlatList} from "react-native";

import To_Do_Layout from "./To_Do_Layout";

//---------------------------------------Generation of Flat List For To-Do----------------------------------
const To_Do_List=({navigation})=>{
    
   
    const [toDo,setToDos]=useState(null);
    
    
    //-----------------Repopulating Data on Navigation using Stack Navigator------------------
    useEffect(() => {
        const unsubscribe = navigation.addListener('focus', () => {
         
          populateToDo();
        });
      return unsubscribe;
      }, [navigation]);

     useEffect(() => {
            populateToDo();
        }, [])
    

        //----------------------Fetching Data from Async Storage----------------------------
    const populateToDo = async () => {
            var a = await AsyncStorage.getItem('toDoList');
            var arr=JSON.parse(a);
            if (arr) {
                setToDos(arr);
            }
            
    }    
    //------------------Navigating to Create a To Do Screen-------------------------------
    const onAdd=()=>{
        navigation.navigate('Create A To-Do');
    }
    //--------------Removing User Name and Logging Out of To-Do---------------------
    const onLogout=async()=>{
        await AsyncStorage.removeItem("username");
        navigation.navigate('Login');
    }

    // Used Touchable Opacity in place of Buttons
    return(
         <View style={{flex:1}}  >
                <View style={{flex:8}}>
                <FlatList data={toDo} renderItem={({item})=>( <To_Do_Layout data={item} navigation={navigation}></To_Do_Layout>
                )}/>
               </View>
               <View style={{flex:1,flexDirection:"row",margin:"2%"}}>
               <TouchableOpacity style={{flex:1} }onPress = {onAdd}>
                    <View style = {{elevation:5,backgroundColor: 'blue',margin:".5%", alignItems: 'center',
                       justifyContent: 'center', borderRadius: 15,flex:1}}>
                       <Text style = {{color: 'white',fontSize:20}}>Add To-Do</Text>
                    </View>
               </TouchableOpacity>
               
               <TouchableOpacity style={{flex:1}} onPress = {onLogout}>
                    <View style = {{elevation:5,backgroundColor: 'white',margin:".5%", alignItems: 'center',
                       justifyContent: 'center', borderRadius: 15,flex:1}}
                       >
                       <Text style = {{color: 'blue',fontSize:20}}>Logout</Text>
                    </View>
               </TouchableOpacity>
              </View>
               
          </View>
     
    );

}

const Styles = StyleSheet.create({
    butt:{
        marginTop:"2.5%",
        borderRadius:10,
        padding:10
    }
})


export default To_Do_List;