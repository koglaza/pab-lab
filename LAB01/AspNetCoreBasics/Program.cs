using Microsoft.AspNetCore.Http;
using System.Text;

#region Empty_Project

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "Hello Dev!");
app.Run();

#endregion

#region Exercise_Host
/*
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environments.Production
});

var app = builder.Build();
if(app.Environment.IsDevelopment())
    app.MapGet("/", () => "Hello Dev!");
else
    app.MapGet("/", () => "Hello Production!");

app.Run();
*/
#endregion

#region Exercise_Routing
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/people/", () => "A list of people");
app.MapGet("/people/{email:alpha}", (string email) => $"A single person with email {email}");
app.MapGet("/people/{age:range(0,100)}", (int age) => $"A list of people having {age} year(s)");
app.MapPut("/people/{email}", (string email) => $"Adding a person with email {email}");

app.Run();
*/
#endregion

#region Exercise_Middleware_1
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("Hello from middleware pre request");
    await next();
    Console.WriteLine("Hello from middleware post request");
});

app.MapGet("/", () => "Exercise middleware");

app.Run();
*/
#endregion

#region Exercise_Middleware_2
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    var requestContent = new StringBuilder();
    requestContent.AppendLine("=== Request Info ===");
    requestContent.AppendLine($"method = {context.Request.Method.ToUpper()}");
    requestContent.AppendLine($"path = {context.Request.Path}");
    requestContent.AppendLine("-- headers");
    foreach (var (headerKey, headerValue) in context.Request.Headers)
    {
        requestContent.AppendLine($"header = {headerKey}    value = {headerValue}");
    }

    requestContent.AppendLine("-- body");
    context.Request.EnableBuffering();
    var requestReader = new StreamReader(context.Request.Body);
    var content = await requestReader.ReadToEndAsync();
    requestContent.AppendLine($"body = {content}");
    Console.Write(requestContent.ToString());
    context.Request.Body.Position = 0;
    await next();
});

app.MapGet("/", () => "Exercise middleware 2");

app.Run();
*/
#endregion

