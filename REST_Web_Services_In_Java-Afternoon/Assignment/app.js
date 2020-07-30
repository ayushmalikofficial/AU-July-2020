var express = require('express');
var app = express();
var fs = require("fs");

const bodyParser = require('body-parser'); 
app.use(bodyParser.json()); 


 var To_Do_List=[{"id":1,"value":"First to do"},{"id":2,"value":"Second to do"},{"id":3,"value":"Third to do"}];

 

//===============================Getting Entire To-Do list====================================

app.get('/listAll', function (req, res) {
        console.log( "Display All Content Function Called" );
        return res.json(To_Do_List);
 })


 //=================================Getting Record by ID=====================================

 app.get('/:id', function (req, res) {
    for(var i = 0; i < To_Do_List.length; i++)
    {
        if(To_Do_List[i].id == req.params.id)
        {
            return res.json(To_Do_List[i]);
        }
     }
        return res.json("No Element with the id found");
 })
 

//===============================Adding a To-Do===================================

app.post('/add', function (req, res) {
    // First read existing users
    var data=JSON.parse(req.body["query"]);
    To_Do_List.push(data);
   return res.json(To_Do_List);
});
 
//===============================Updating a To-Do===================================

app.post('/update', function (req, res) {
    var data=JSON.parse(req.body["query"]);

    for(var i = 0; i < To_Do_List.length; i++)
    {
        if(To_Do_List[i].id == data.id)
        {
            To_Do_List[i].value=data.value;
            return res.json(To_Do_List[i]);
        }
     }
        return res.json("No Element with the given id found")
});

//===================================Deleting a To-Do by ID==================================
app.delete('/delete/:id', function (req, res) {
    for(var i = 0; i < To_Do_List.length; i++)
    {
        if(To_Do_List[i].id == req.params.id)
        {
            To_Do_List.splice(i,1);
            return res.json(To_Do_List)
        }
        }
        return res.json("No Element with the given id found")
    }) 
 
//============================Connecting to Port:3000 and Host:127.0.0.1============================


var server = app.listen(3000, function () {
    var host = '127.0.0.1';
    var port = server.address().port
    console.log("Example app listening at http://%s:%s", host, port)
 })


