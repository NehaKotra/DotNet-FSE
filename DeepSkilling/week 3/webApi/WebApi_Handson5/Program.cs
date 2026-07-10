/*
============================================================
CTS Deep Skilling

Web API Handson 5

JWT Authentication

Commands

Create Project

dotnet new webapi -n WebApi_Handson5

Install Packages

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

dotnet add package System.IdentityModel.Tokens.Jwt

Run

dotnet run

============================================================
*/

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

string securityKey = "mysuperdupersecret";

var symmetricSecurityKey =
    new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(securityKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "mySystem",

            ValidAudience = "myUsers",

            IssuerSigningKey =
                symmetricSecurityKey
        };
});

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();