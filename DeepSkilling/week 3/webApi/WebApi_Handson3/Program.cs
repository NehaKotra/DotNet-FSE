/*
============================================================
CTS Deep Skilling

Web API Handson 3

Commands

Create Project

dotnet new webapi -n WebApi_Handson3

Install Packages

dotnet add package Swashbuckle.AspNetCore

dotnet add package Microsoft.AspNetCore.Mvc.WebApiCompatShim

Run

dotnet run

Swagger

https://localhost:5001/swagger

============================================================
*/

using WebApi_Handson3.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CustomAuthFilter>();

builder.Services.AddScoped<CustomExceptionFilter>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();