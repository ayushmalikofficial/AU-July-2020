import React, { useState, useEffect } from 'react'
import ToDoForm from './ToDoForm'

// This uses Hooks and Functional Components

function ToDoList() {
  
    const [content, setContent]=useState({currentIndex:-1,list:[] } )
    
    useEffect(() => {
        console.log("Use Effect is called");
        setContent({ currentIndex: -1, list:returnList()});
    }, [])

    
    const returnList=()=> {
      if (localStorage.getItem('todolist') == null)
         localStorage.setItem('todolist', JSON.stringify([]))
        return JSON.parse(localStorage.getItem('todolist'))
    }
    
    const handleEdit = (index) => {
        setContent({currentIndex: index})
    }
    
    const handleDelete = (index) => {
        var templist = returnList()
        templist.splice(index, 1);
        localStorage.setItem('todolist', JSON.stringify(templist))
        setContent({ currentIndex: -1,list:templist })
    }
    
    const onAddOrEdit = (data) => {
        var templist = returnList()
        if (content.currentIndex == -1)
            templist.push(data)
        else
            templist[content.currentIndex] = data
        localStorage.setItem('todolist', JSON.stringify(templist))
        setContent({ currentIndex: -1,list:templist })
    }
    
    return (
            <div >
                <ToDoForm 
                currentIndex={content.currentIndex}
                list={content.list}
                onAddOrEdit={onAddOrEdit}/>
                <hr />
                <table style={{marginLeft:10}}>
                    <tbody >
                        {content.list.map((item, index) => {
                            return <tr style={{fontSize:13,backgroundColor:"#F8F8F8",borderRadius:10}} key={index}>
                                <td style={{padding:10, borderRadius:10}} >{item.todo}</td>
                                <td style={{borderRadius:10}}><button style={{margin:10,border:0,padding:5,borderRadius:6,width:70,backgroundColor:"#8FDC7E",color:"white"}}onClick={handleEdit(index)}>Edit</button></td>
                                <td style={{borderRadius:10}}><button style={{margin:10,border:0,padding:5,borderRadius:6,width:70,backgroundColor:"#E96F6F",color:"white"}}onClick={handleDelete(index)}>Delete</button></td>
                            </tr>
                        })}
                    </tbody>
                </table>
            </div>
        )
    
}


export default ToDoList

  
 