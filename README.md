##TASK LIST :notebook:
---
A web API build with C# (.NET 6)
This api simiulate a **TO-DO** list

> Endpoints ([https://localhost:7098/Tarefa]()):
    
* [POST] - [/](): Create a new item to remember
* [GET] - [/ObterTodos](): Get all the records   
* [GET] [/3](): Returns the to-do item identified by 3
* [GET] - [/ObterPorTitulo?titulo=Medicação](): Returns a list of to-do with the title **"Medicação"** 
* [GET] - [/ObterPorData?_data=2022%2F12%2F20](): Returns a list of to-do with the date **20/12/2022**
* [GET] - [/ObterPorStatus?status=1](): Returns a to-do list with the status **1**
* [PUT] - [/1](): Change a record identified by **1**. **Obs.:** This endpoint must have a json body with the updated task
* [DELETE] - [/1]():
Endpoint to delete the record identified by **1**