/*
============================================================
CTS Deep Skilling
Lab 3 - Using EF Core CLI to Create and Apply Migrations
============================================================

Objective
---------
Learn how to use EF Core CLI to manage database schema
changes using migrations.

Steps
-----

1. Install EF Core CLI (if not installed)

dotnet tool install --global dotnet-ef

2. Create Initial Migration

dotnet ef migrations add InitialCreate

3. Apply Migration

dotnet ef database update

4. Verify Database

Open SQL Server Management Studio (SSMS) or
Azure Data Studio and verify that:

• RetailInventoryDB is created.
• Categories table exists.
• Products table exists.

============================================================
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("EF Core 8.0");
        Console.WriteLine("Lab 3 - Migrations");
        Console.WriteLine("=====================================\n");

        Console.WriteLine("Migration Commands\n");

        Console.WriteLine("1. Install EF CLI");
        Console.WriteLine("   dotnet tool install --global dotnet-ef\n");

        Console.WriteLine("2. Create Migration");
        Console.WriteLine("   dotnet ef migrations add InitialCreate\n");

        Console.WriteLine("3. Update Database");
        Console.WriteLine("   dotnet ef database update\n");

        Console.WriteLine("4. Verify Database in SQL Server");

        Console.WriteLine("\nLab 3 Completed Successfully.");
    }
}

/*
============================================================

Expected Output

=====================================
EF Core 8.0
Lab 3 - Migrations
=====================================

Migration Commands

1. Install EF CLI
2. Create Migration
3. Update Database
4. Verify Database in SQL Server

Lab 3 Completed Successfully.

============================================================

Analysis

Migration is a feature of Entity Framework Core that
keeps the database schema synchronized with the C#
model classes.

Advantages

• Version control for database
• Easy schema updates
• Automatic table creation
• Safe database modifications

Time Complexity

Migration Creation : O(1)

Database Update : Depends on schema changes

============================================================
*/