/*
============================================================
CTS Deep Skilling
Lab 1 - Understanding ORM
============================================================

ORM (Object Relational Mapping)

ORM maps C# classes to relational database tables.
It allows developers to work with C# objects instead of
writing SQL queries manually.

Benefits
--------
• Faster development
• Less SQL code
• Better maintainability
• Automatic CRUD operations
• Database independence

EF Core vs EF Framework
-----------------------
Entity Framework Core
• Cross-platform
• Lightweight
• Supports LINQ
• Async queries
• Better performance

Entity Framework 6
• Windows only
• Larger framework
• More mature
• Less flexible

EF Core 8 Features
------------------
• JSON column mapping
• Compiled models
• Better performance
• Bulk operations
• Interceptors

Commands
--------
dotnet new console -n RetailInventory
cd RetailInventory

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design

============================================================
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Retail Inventory System");
        Console.WriteLine("Lab 1 - Entity Framework Core");
        Console.WriteLine();
        Console.WriteLine("ORM maps C# classes to SQL Server tables.");
        Console.WriteLine("Entity Framework Core simplifies database operations.");
    }
}