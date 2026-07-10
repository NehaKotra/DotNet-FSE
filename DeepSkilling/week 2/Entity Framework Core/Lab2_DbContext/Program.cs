/*
============================================================
CTS Deep Skilling
Lab 2 - Setting Up the Database Context
============================================================

Objective
---------
Configure DbContext and connect to SQL Server.

Models
------
• Category
• Product

Database Context
----------------
• AppDbContext

Commands
--------

Create Project
dotnet new console -n RetailInventory

Go to Project
cd RetailInventory

Install Packages
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design

Build Project
dotnet build

Run Project
dotnet run

============================================================
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("Database Context Created Successfully.");
        Console.WriteLine("Products DbSet : " + context.Products);
        Console.WriteLine("Categories DbSet : " + context.Categories);
    }
}