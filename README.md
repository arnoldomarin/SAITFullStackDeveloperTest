# SAITFullStackDeveloperTest

## Table of Contents
1. [General Info](#general-info)
2. [Technologies](#technologies)
3. [Launch](#launch)
4. [Important files](#important-files)
4. [Known Bugs](#known-bugs)

## General Info
***
A web application that displays a list of programs at SAIT obtained from a CSV file (TextFile1.txt). The user is able to add and delete programs and those changes will be reflected in the UI and in the CSV file. The user can also search the table of programs by program Status or by Priority. 

## Technologies
***
A list of technologies used within the project:
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.Net Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0)
* [HTML](https://www.w3schools.com/html/)
* [CSS](https://www.w3schools.com/css/)
* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
* [JavaScript](https://www.javascript.com/)

## Launch
***

Please follow the steps for best compatibility:

* Clone the repository to your local machine
* Open project using Visual Studio 2019 by running the SAITFullStackDeveloperTest.sln file
* Execute project with your preferred browser (green arrow)
* Project is running and ready to perform the tasks needed!

## Important Files
***

List of the main files with the code that allows to perform the tasks needed.

Model: 
* SaitPrograms.cs (Models/SaitPrograms.cs) - Contains the data related logic that interacts with teh CSV file 

Controller: 
* ProgramController.cs (Controllers/ProgramController.cs) - gets data from the model and passes the data to the view. Receives input from the view and processes requests.

Support Files (Interact with Controller to perform tasks) 
* ProgramList.cs (Repository/ProgramList.cs) - Contains all the logic that is called by ProgramRepository to perform tasks in ProgramController.cs
* ProgramRepository.cs (Repository/ProgramRepository.cs) - Calls ProgramList.cs functions to performs tasks 

Views: 
* Index.cshtml (Views/Index.cshtml) - Contains html for the main page of the application
* Create.cshtml (Views/Create.cshtml) - Contains html for the create page of the application
* Delete.cshtml (Views/Delete.cshtml) - Contains html for the delete page of the application

CSV File: 
* FileText1.txt - contains the data of the program

## Known Bugs
***
* It is important to know that sometimes when you try to delete a program that you just added to the table, the program will not delete it but it will delete other programs that were already on the list.
