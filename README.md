# Time Management Service API

## Project Information
- Project Name: time Management Service
- Student Name: Yatri Rohitbhai Patel
- Student Number - 8980053

## Microservice Description

This is a complete microservice of time management. The service offers a full CRUD API to monitors tasks where the data includes task name, description, due date, task category, task satus, and amount of time spent on task. 

## Domain Model: TimeEntry

TimeEntry model reflects individual tasks that have the following properties.

- id (int) - it is a primary key for time entry.
- TaskName (string) - requires, and name of the task in the length of 4 to 100 characters.
- Description (string) - optional, details of the task 
- DueDate (DateTime) - required, deadline of completing task
- TaskCategory (string) - optional, category type of task
- TaskStatus (string) - reuired, default one is pending.
- TimeSpent (int) - required, minutes spent on tsak the range in 0 to 2000
- CreatedAt (DateTime) - When the task was created, it is auto set.
- UpdatedAt (DateTime? , nullable) - when the task was last updated it is automatically change.

## API Endpoints

- GET - /api/TimeEntries - get all time entries - 200 Ok
- POST - /api/TimeEntries - create new time entry - 201 created, 404 bad request
- GET - /api/TimeEntries/{id} - get a specific time entry using id - 200 OK, 404 NOT found
- PUT - /api/TimeEntries/{id} - update an existing time entry - 202 accepted, 400 bad request, 404 Not Found
- DELETE - /api/TimeEntries/{id} - deleting existing time entry - 204 not content, 404 Not Found

# API Base URL -
http://localhost:5249/api/TimeEntries

# swagger url - 
   http://localhost:5249/Swagger/index.html 

# Run Web API :
1. Clone downloaded project using [https://github.com/YatriPatel17/TimeManagementService]
2. Restore all dependencies using [dotnet restore]
3. Apply database migrations using [dotnet ef database update]
4. Run the application [dotnet run]
5. For swagger, navigate to https://localhost:port/swagger