/*
============================================================
CTS Deep Skilling

Web API Handson 2 - Swagger & Postman

Commands
--------

Create Project

dotnet new webapi -n WebApi_Handson2

Go to Project

cd WebApi_Handson2

Install Swagger

dotnet add package Swashbuckle.AspNetCore

Run

dotnet run

Swagger URL

https://localhost:5001/swagger

============================================================
*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "Web API Demo",
        TermsOfService = new Uri("https://example.com"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "John Doe",
            Email = "john@xyzmail.com",
            Url = new Uri("https://www.example.com")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "License Terms",
            Url = new Uri("https://www.example.com")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();