import React, {useState, useEffect} from "react"

import { Alert,View,Text,TouchableOpacity,TextInput,StyleSheet,AsyncStorage} from "react-native";

//------------------------------Login Screen-----------------------------------------------
const Login=({navigation})=>{

    const [username, setUserName] = useState(null);

    // For Re-Directing on using Back Button in Android/ Back header in Stack Navigator
    useEffect(() => {
        const unsubscribe = navigation.addListener('focus', () => {
         
          checkAuth();
        });
      return unsubscribe;
      }, [navigation]);


   // -----------------------Same code as used in the class------------------
      useEffect(() => {
        checkAuth()
    }, [])

    const checkAuth = async () => {
        const userName = await AsyncStorage.getItem("username");
        if (userName) {
            navigation.navigate('Your To-Do List');
        }
        return;
    }

    const onLogin=async()=>{
        if(username)
        {
            await AsyncStorage.setItem("username", username);
            navigation.navigate('Your To-Do List');
        }
       else
       {
        // Alert on Empty User Name
        Alert.alert("",
            "User Name can not be empty"
            );
       }

    }
    //------------------------------------------------------------------------
    //Used Touchable Opacity instead of Button for better customisation
    return(
          <View style={{flex:1}}>
                        <View style={Styles.container}>
                                <Text style={Styles.loginTextStyle}>Welcome</Text>
                                <TextInput style={Styles.textInputStyle} onChangeText={(text) => setUserName(text)} placeholder="Enter Your User Name" />
                        </View>
                        <View style={{flex:5}}></View>
                      
                        <View style={{flex:1,flexDirection:"row",margin:"2%"}}>
                            
                            <TouchableOpacity style={{flex:1}} onPress = {onLogin}>
                                    <View style = {{elevation:5,backgroundColor: 'white',margin:".5%", alignItems: 'center',
                                    justifyContent: 'center', borderRadius: 15,flex:1}}
                                    >
                                    <Text style = {{color: 'blue',fontSize:20}}>Log In</Text>
                                    </View>
                            </TouchableOpacity>
                        
                            </View>
                            
          </View>
    );

}

const Styles = StyleSheet.create({
    container: {
        flex: 3,
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

export default Login;