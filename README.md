
# Welcome to the Code-Challenge-Project wiki!

_Main aim of the project is understanding well RESTful API, and build a simple javascript-based web front-end to consume that API._

**Frameworks, Technologies, and Environments Used in the Project**
* Frameworks - 
ASP.NET MVC, ADO.NET, Entity Framework  
* Languages -
C#, JQuery, HTML,CSS, LINQ
* Environments -
Windows 10, Microsoft Visual Studio 2015, Microsoft SQL Server 2014, Google Chrome, Fiddler 


## How to run the project ??

**Since parsing of the file task already done just download Code Challenge Project visual studio project and the click project link .sln in the file than it runs :) 

Or I host the project on [THIS LINK ](http://albayraktaroglu.net/) just go and have a try :) 
**

## Code Challange Question Dump file 

In order to understand the file C# console application written [Code Challenge Parser](https://github.com/albayraktaroglu/Code-Challenge-Parser)

Basically what it does is it reads the file then fill the Database for later use by this project. 

The data is tabular, with each column separated by a vertical pipe, '|'. The column headings are 'question', 'answer' and 'distractors'. Each record represents a single multiple choice question. If multiple distractors (a wrong answer) exist they are separated by a comma. Below is an example: 

`question|answer|distractors What is 7343 + 6708?|635|688, 7171, 7023 `

## API Instructions
* Basically API is consisting of 4 fundamental HTTP Requests - GET, POST, PUT and DELETE 

**_Http Methods Implemented in the API_**

![Http Methods Implemented in the API](https://maxoffsky.com/word/wp-content/uploads/2012/11/RESTful-API-design-620x263.jpg)

// GET: api/Questions

`public IHttpActionResult GetQuestions()`

display all questions from the given file

// GET: api/Questions/5

`public IHttpActionResult GetQuestion(int id)`

display a question by id from the given file

// PUT: api/Questions/5

`public HttpResponseMessage Put(List<string> val)`

updates given question's operands, math operations and options of the question  

// POST: api/Questions

`public HttpResponseMessage PostQuestion(List<string> val)`

creates new questions with options

// DELETE: api/Questions/5

`public IHttpActionResult DeleteQuestion(int id)`

deletes the question by id


## How can you see the API results 

Fiddler is a useful application for the testing HTTP Methods so in order to see the results you need to first filter the other traffic from the left side which shows the HTTP Requests and Responses. In order to do that if you run it on local filter by host that means you are going to filter something like http://localhost:xxxx/. The picture below shows how it is look like. 

![](https://www.blackbaud.com/files/support/guides/infinitydevguide/Subsystems/tasks-developer-help/Content/Resources/Images/InfinityWebAPI/UsingFiddlerWalkthru5_746x417.png)


## Some examples for how to call the RESTful API functions ?? 

* Examples supposed run it at local 

**Brings all the Questions**
http://localhost:XXXX/api/Questions

**Brings all the Questions by Qid**
http://localhost:XXXX/api/Questions/5

Since URL strings are going to be same for the rest of the RESTful API functions such as PUT, POST and DELETE, you need to use Fiddler's dropdown http methods list  or your browsers network section such as the picture below while [Project Page](http://albayraktaroglu.net) is open. 

![](http://blog.mozilla.org/hacks/files/2013/05/network-monitor.png)





