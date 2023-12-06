# IntuitiveTechTest
A .NET backend WebApi

## Prerequisites
* Install .NET 8.0 SDK https://dotnet.microsoft.com/en-us/download/dotnet/8.0
* Install dotnet-ef tools to run migrations, from the terminal: `dotnet tool install --global dotnet-ef`
* Install PostgreSQL database server https://www.postgresql.org/download/

## How to start the application
In the project directory:
* Run the migrations to create the database (make sure PostgreSQL is running in the background): `dotnet ef database update`
* Run the app from the terminal `dotnet watch run` or use Visual Studio, Swagger page should automatically open in the browser where you will be able to run the endpoints, or go to http://localhost:5257/swagger/index.html

## Endpoints
* `GET /Airports` get list of airports
* `GET /Airports/{id}` get single airport details by id
* `GET /Countries` get list of countries
* `POST /Countries` add new country
  * Request body example:
    ```
    {
      "name": "Iceland"
    }
    ```
* `DELETE /Countries/{id}` delete country by id
* `GET /Routes` get a list of all routes (airport routes and airport group routes)
* `POST /Routes` add a new airport route or airport group route or both
  * Request body example for airport route:
    ```
    {
      "departureAirportId": 1,
      "arrivalAirportId": 2
    }
    ```
  * Request body example for airport group route:
    ```
    {
      "departureAirportGroupId": 1,
      "arrivalAirportGroupId": 2
    }
    ```
  * Request body example for both:
    ```
    {
      "departureAirportId": 1,
      "arrivalAirportId": 2,
      "departureAirportGroupId": 1,
      "arrivalAirportGroupId": 2
    }
    ```

## What I would do next
* Refactor services validation logic into separate methods
* Add unit tests
* Add more endpoints
