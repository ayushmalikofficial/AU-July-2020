import React, { Component } from 'react'
import ToDoForm from './component/ToDoForm'

// This uses Class Component and State, a similar implementation of this file using Functional Component and Hooks can be found in ToDoList.js 

class ToDolist extends Component {
    state = {
        currentIndex: -1,
        list: this.returnList()
    }

    returnList() {
        if (localStorage.getItem('todolist') == null)
            localStorage.setItem('todolist', JSON.stringify([]))
        return JSON.parse(localStorage.getItem('todolist'))
    }

    handleEdit = (index) => {
        this.setState({
            currentIndex: index
        })
    }

    handleDelete = (index) => {
        var list = this.returnList()
        list.splice(index, 1);
        localStorage.setItem('todolist', JSON.stringify(list))
        this.setState({ list, currentIndex: -1 })
    }

    onAddOrEdit = (data) => {
        var list = this.returnList()
        if (this.state.currentIndex == -1)
            list.push(data)
        else
            list[this.state.currentIndex] = data
        localStorage.setItem('todolist', JSON.stringify(list))
        this.setState({ list, currentIndex: -1 })
    }


    render() {
        return (
            <div >
                <ToDoForm 
                    currentIndex={this.state.currentIndex}
                    list={this.state.list}
                    onAddOrEdit={this.onAddOrEdit}
                />
                <hr />
                <table style={{marginLeft:10}}>
                    <tbody >
                        {this.state.list.map((item, index) => {
                            return <tr style={{fontSize:13,backgroundColor:"#F8F8F8",borderRadius:10}} key={index}>
                                <td style={{padding:10, borderRadius:10}} >{item.todo}</td>
                                <td style={{borderRadius:10}}><button style={{margin:10,border:0,padding:5,borderRadius:6,width:70,backgroundColor:"#8FDC7E",color:"white"}}onClick={() => this.handleEdit(index)}>Edit</button></td>
                                <td style={{borderRadius:10}}><button style={{margin:10,border:0,padding:5,borderRadius:6,width:70,backgroundColor:"#E96F6F",color:"white"}}onClick={() => this.handleDelete(index)}>Delete</button></td>
                            </tr>
                        })}
                    </tbody>
                </table>
            </div>
        )
    }
}

export default ToDolist
