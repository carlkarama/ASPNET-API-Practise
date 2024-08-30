using Microsoft.AspNetCore.Http.HttpResults;

/*
    In this file, ASP.NET Core apps are configured. It will launch a host
    responsible for starting the application, configuring an underlying HTTP server
    and setting up the pipeline for processing requests & responses over HTTP. 
*/

var builder = WebApplication.CreateBuilder(args); // provides us with API's for configuring the application host
var app = builder.Build(); // configures the request-response pipeline behind the scenes. Allows users to configure route handlers in their app

var todos = new List<Todo>();

app.MapGet("/todos", () => todos);

app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound> (int id) => {
    var targetTodo = todos.SingleOrDefault(t => id == t.Id);
    return targetTodo is null ? TypedResults.NotFound() : TypedResults.Ok(targetTodo);
});

app.MapPost("/todos", (Todo task) => 
{
    todos.Add(task);
    return TypedResults.Created("/todos/{id}", task);
});

app.MapDelete("/todos/{id}", (int id) => {
    todos.RemoveAll(t => t.Id == id);
    return TypedResults.NoContent();
});

app.Run();

public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted) {}