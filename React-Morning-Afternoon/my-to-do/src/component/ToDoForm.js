import React, { Component } from 'react'


// This uses Class Component and State 


class ToDoForm extends Component {

    state = {
        ...this.returnStateObject()
    }

    returnStateObject() {
       console.log("Return State Object is called")
        if (this.props.currentIndex == -1)
            return {
                todo: ''
            }
        else
            return this.props.list[this.props.currentIndex]
    }

    componentDidUpdate(prevProps) {
        console.log("Component Did update is called")
       if (prevProps.currentIndex != this.props.currentIndex || prevProps.list != this.props.list) {
         this.setState({ ...this.returnStateObject() })
          console.log(prevProps, this.props)
       }
    }

    handleInputChange = (e) => {
        console.log("Handle Input Change is called")
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    handleSubmit = (e) => {
        e.preventDefault()
        console.log("Handle Submit is called")
        this.props.onAddOrEdit(this.state)
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit} autoComplete="off">   
                <input style={{fontSize:15,width:"30%",margin:10,border:0,backgroundColor:"#F8F8F8",borderRadius:6,padding:5}} name="todo" placeholder="Enter Task" onChange={this.handleInputChange} value={this.state.todo} />
                <button style={{margin:10,border:0,padding:5,borderRadius:6,width:70,backgroundColor:"#338AFF",color:"white"}}type="submit">Add</button>
                <br/>
            </form>
        )
    }
}

export default ToDoForm