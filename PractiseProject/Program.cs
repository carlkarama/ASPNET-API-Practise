/*
    In this file, ASP.NET Core apps are configured. It will launch a host
    responsible for starting the application, configuring an underlying HTTP server
    and setting up the pipeline for processing requests & responses over HTTP. 
*/

var builder = WebApplication.CreateBuilder(args); // provides us with API's for configuring the application host
var app = builder.Build(); // configures the request-response pipeline behind the scenes. Allows users to configure route handlers in their app

app.MapGet("/", () => "Hello World!");

app.Run();
