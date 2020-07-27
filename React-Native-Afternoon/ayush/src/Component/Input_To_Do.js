import React, { useState } from "react"

import { View,Text,TouchableOpacity,TextInput,StyleSheet,AsyncStorage} from "react-native";


//--------------------------------------------Function For Creating New To Do--------------------------------
const Input_To_Do=({navigation})=>{

    const [new_ToDo, setToDo] = useState("");


    // -----------------Adding a New To-Do--------------------------
    const onAdd=async()=>{

           const a = await AsyncStorage.getItem('toDoList');
            
            if (a == null) {
              let obj = [];
              obj.push(new_ToDo);
              await AsyncStorage.setItem('toDoList', JSON.stringify(obj));
            }
            else{
               let arr = JSON.parse(a);              
               arr.push(new_ToDo);
                await AsyncStorage.setItem('toDoList', JSON.stringify(arr));
            }          
        navigation.navigate('Your To-Do List');
    }
    
    //-------------Cancel adding a record-------------------------
    const onClick=()=>{   
        navigation.navigate('Your To-Do List');
    }
    
    // Used Touchable Opacity for Buttons
    return(
          <View style={{flex:1}}>
                        <View style={Styles.container}>
                                <TextInput style={Styles.textInputStyle} onChangeText={(text) => setToDo(text)} placeholder="Enter what you wish to do" />
                         </View>
    
                    <View style={{flex:1,flexDirection:"row",margin:"2%"}}>
                        <TouchableOpacity style={{flex:1} }onPress = {onAdd}>
                        <View style = {{elevation:5,backgroundColor: 'blue',margin:".5%", alignItems: 'center',
                           justifyContent: 'center', borderRadius: 15,flex:1}}>
                           <Text style = {{color: 'white',fontSize:20}}>Create</Text>
                        </View>
                   </TouchableOpacity>
                   
                   <TouchableOpacity style={{flex:1}} onPress = {onClick}>
                        <View style = {{elevation:5,backgroundColor: 'white',margin:".5%", alignItems: 'center',
                           justifyContent: 'center', borderRadius: 15,flex:1}}
                           >
                           <Text style = {{color: 'blue',fontSize:20}}>Cancel</Text>
                        </View>
                   </TouchableOpacity>
                    </View>            
          </View>
    );

}

const Styles = StyleSheet.create({
    container: {
        flex: 8,
        backgroundColor:"white",
        borderRadius:15,
        elevation:5,
        margin:"1.5%"
    },
    loginTextStyle: {
        fontSize: 20,
        fontWeight: "200",
        alignItems:'flex-start',
        color:'blue',
        padding:10
    },
    
    textInputStyle: {
        
        borderWidth: 0,
        borderRadius: 5,
        fontSize: 20,
        padding: 10,
       
        marginBottom: 20
    }
})

export default Input_To_Do;