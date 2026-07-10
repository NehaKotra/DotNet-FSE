/*
============================================================
CTS Deep Skilling

Web API Handson 1

Commands

Create Project

dotnet new webapi -n WebApi_Handson1

Go to Project

cd WebApi_Handson1

Run

dotnet run

Open Browser

https://localhost:5001/api/values

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