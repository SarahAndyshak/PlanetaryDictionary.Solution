## Planetary Dictionary

#### By Sarah Andyshak, David Jandron, Ashe Urban, Asia Kaplanyan, Mesha Devan, Jackson Levine

#### An API for interstellar exploration.

## Technologies Used

* C#
* .NET
* ASP.Net
* Entity Framework

## Description

An API providing vital facts about the universe. 

## How To Run This Project

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c).

If you have not already, install the `dotnet-ef` tool by running the following command in your terminal:

```
dotnet tool install --global dotnet-ef --version 6.0.0
```

### Set Up and Run Project

1. Clone this repo.
2. Open the terminal and navigate to this project's production directory called "PlanetaryDictionary".
3. Within the production directory "PlanetaryDictionary", create two new files: `appsettings.json` and `appsettings.Development.json`.
4. Within `appsettings.json`, put in the following code. Make sure to replacing the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL. For the LearnHowToProgram.com lessons, we always assume the `uid` is `root` and the `pwd` is `epicodus`.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=planetary_dictionary;uid=root;pwd=epicodus;"
  }
}
```

5. Within `appsettings.Development.json`, add the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

6. Create the database using the migrations in the Planetary Dictionary API project. Open your shell (e.g., Terminal or GitBash) to the production directory "PlanetaryDictionary", and run `dotnet ef database update`. You may need to run this command for each of the branches in this repo. 
    - To optionally create a migration, run the command `dotnet ef migrations add MigrationName` where `MigrationName` is your custom name for the migration in UpperCamelCase. To learn more about migrations, visit the LHTP lesson [Code First Development and Migrations](https://www.learnhowtoprogram.com/c-and-net-part-time/many-to-many-relationships/code-first-development-and-migrations).
7. Within the production directory "PlanetaryDictionary", run `dotnet watch run --launch-profile "PlanetaryDictionary-Production"` in the command line to start the project in production mode with a watcher. 
8. To optionally further build out this project in development mode, start the project with `dotnet watch run` in the production directory "PlanetaryDictionary".
9. Use your program of choice to make API calls. In your API calls, use the domain _http://localhost:5000_. Keep reading to learn about all of the available endpoints.

## Testing the API Endpoints

You are welcome to test this API via [Postman](https://www.postman.com/), [curl](https://curl.se/), or [the ASP.NET Core MVC frontend "Planetary Dictionary Client"](https://github.com/epicodus-lessons/section-6-cretaceous-park-api-csharp-net6) create to work with this API. 

If you want to use the Planetary Dictionary Client, an ASP.NET Core MVC application, follow the setup instructions in the README of [this repo](https://github.com/epicodus-lessons/section-6-cretaceous-park-api-csharp-net6). 

### Available Endpoints

```
GET http://localhost:5000/api/planets/
GET http://localhost:5000/api/planets/{id}
POST http://localhost:5000/api/planets/
PUT http://localhost:5000/api/planets/{id}
DELETE http://localhost:5000/api/planets/{id}
```

Note: `{id}` is a variable and it should be replaced with the id number of the animal you want to GET, PUT, or DELETE.

#### Optional Query String Parameters for GET Request

GET requests to `http://localhost:5000/api/planets/` can optionally include query strings to filter or search planets.

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| name        | String      | not required | Returns planets with a matching name value |
| population  | Int         | not required | Returns planets with a matching population value |



The following query will return all planets with the name "Mars":

```
GET http://localhost:5000/api/planets?name=mars
```

#### Additional Requirements for POST Request

When making a POST request to `http://localhost:5000/api/planets/`, you need to include a **body**. Here's an example body in JSON:

```json
{
  "name": "Mercury",
  "funFact": "This planet is shrinking! Mercury has no moons, and has volcanic activity.",
  "climate": "The surface is both extremely hot and cold, with temperatures ranging from 800F to -290F.",
  "lifeFormDetails": "Steves, crablike humanoids, 3 inches tall, 5 claws and no head, eyes on feet",
  "population": 36000000
}
```

#### Additional Requirements for PUT Request

When making a PUT request to `http://localhost:5000/api/planet/{id}`, you need to include a **body** that includes the planets's `planetId` property. Here's an example body in JSON:

```json
{
  "planetId": 1,
  "name": "Mercury",
  "funFact": "This planet is shrinking! Mercury has no moons, and has volcanic activity.",
  "climate": "The surface is both extremely hot and cold, with temperatures ranging from 800F to -290F.",
  "lifeFormDetails": "Steves, crablike humanoids, 3 inches tall, 5 claws and no head, eyes on feet",
  "population": 36000000
}
```

And here's the PUT request we would send the previous body to:

```
http://localhost:5000/api/planet/1
```

Notice that the value of `planetId` needs to match the id number in the URL. In this example, they are both 1.

## Known Bugs

* No known issues.

## License
Enjoy the site! If you have questions or suggestions for fixing the code, please contact us!

[MIT](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt)

Copyright (c) 2023 Sarah Andyshak, David Jandron, Ashe Urban, Asia Kaplanyan, Mesha Devan, Jackson Levine