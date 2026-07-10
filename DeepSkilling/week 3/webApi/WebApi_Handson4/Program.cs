/*
============================================================
CTS Deep Skilling

Web API Handson 4

Commands
--------

Create Project

dotnet new webapi -n WebApi_Handson4

Install Swagger

dotnet add package Swashbuckle.AspNetCore

Run

dotnet run

Swagger

https://localhost:5001/swagger

============================================================
*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();