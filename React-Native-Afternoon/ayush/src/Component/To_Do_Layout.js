import React from "react"

import { Text, View,TouchableOpacity,StyleSheet,AsyncStorage,Alert} from "react-native";

//---------------------Structure File of A To-Do---------------------
const To_Do_Layout=(props)=>{
    
    const{data,navigation}=props;
    
    //---------Deleting A To-Do on Long Press-------------------
    const onDelete=async()=>{
            const a = await AsyncStorage.getItem('toDoList');
            var arr = await JSON.parse(a);

            var index = await arr.indexOf(data);
            if(index == -1){
                return;
            }
            await arr.splice(index, 1);
            await AsyncStorage.setItem('toDoList', JSON.stringify(arr));          
            navigation.navigate('Your To-Do List');
    }

//-----------------Layout of a To Do---------------------------
    return(
          <View style={Styles.card}>
          <TouchableOpacity style={Styles.container} onLongPress={onDelete} >
            <View style={Styles.background} >
                <Text style={Styles.title}>{data}</Text>
            </View>
        </TouchableOpacity>
          
          </View>
     
    );

}

const Styles = StyleSheet.create({
    card:{
        paddingTop:5
    },
    title: {
        fontSize: 16,
        color: "black",
        fontWeight: "200",
        padding: 15,
        alignSelf: "flex-start",
        justifyContent:"center"
    },
    source: {
        fontSize: 16,
        color: "blue",
        fontWeight: "300",
        padding: 15,
        alignSelf: "flex-start"
    },
    background: {
        elevation:5,
        backgroundColor: 'white',
        margin:".5%", 
        alignItems: 'center',
        justifyContent: 'center',
        borderRadius: 15,
        flex:1
    },
    container: {
        
        width: "95%",
        flex:1,
        marginLeft: "2.5%",
        marginRight: "2.5%",
        marginVertical: 5,
        elevation:5
    }

})


export default To_Do_Layout;