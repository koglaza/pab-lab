using Microsoft.AspNetCore.Http;
using System.Text;

#region Exercise_Http_Methods

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => { return Results.Ok(); });
app.MapPost("/", () => { return Results.Created(); });
app.MapPut("/", () => { return Results.Created(); });
app.MapPatch("/", () => { return Results.Ok(); });
app.MapDelete("/", () => { return Results.NoContent(); });

app.Run();

#endregion

#region Exercise_CRUD
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Person> people = new List<Person>();
Person LocalFunction_GetPersonById(string email)
    => people.SingleOrDefault(p => p.Email == email);

app.MapGet("/{email}", (string email) => LocalFunction_GetPersonById(email));

app.Run();

public class Person
{
    public string Email { get; set; }
}
*/
#endregion

#region Exercise_Swagger
/*
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
*/
#endregion
