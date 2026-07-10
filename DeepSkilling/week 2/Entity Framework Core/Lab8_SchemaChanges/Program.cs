/*
============================================================
CTS Deep Skilling
Lab 8 - Managing Migrations and Schema Changes
============================================================

Objective
---------
Update the Product model by adding a new field
StockQuantity and apply the changes using EF Core
Migrations.

Step 1
------
Update Product.cs

public int StockQuantity { get; set; }

Step 2
------
Create Migration

dotnet ef migrations add AddStockQuantity

Step 3
------
Update Database

dotnet ef database update

Step 4
------
Verify in SQL Server

Check that the Products table contains the
StockQuantity column.

============================================================
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======================================");
        Console.WriteLine("Lab 8 - Schema Changes");
        Console.WriteLine("======================================");

        Console.WriteLine();

        Console.WriteLine("Added New Property");

        Console.WriteLine("Product.StockQuantity");

        Console.WriteLine();

        Console.WriteLine("Migration Command");

        Console.WriteLine("dotnet ef migrations add AddStockQuantity");

        Console.WriteLine();

        Console.WriteLine("Database Update Command");

        Console.WriteLine("dotnet ef database update");

        Console.WriteLine();

        Console.WriteLine("Verify the Products table contains");

        Console.WriteLine("StockQuantity column.");

        Console.WriteLine();

        Console.WriteLine("Lab 8 Completed Successfully.");
    }
}

/*
============================================================

Required Change in Product.cs

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}

============================================================

Expected Output

======================================
Lab 8 - Schema Changes
======================================

Added New Property

Product.StockQuantity

Migration Command

dotnet ef migrations add AddStockQuantity

Database Update Command

dotnet ef database update

Verify the Products table contains

StockQuantity column.

Lab 8 Completed Successfully.

============================================================

Analysis

Migration Process

1. Modify Product Model.
2. Generate Migration.
3. Apply Migration.
4. Verify Database Schema.

Advantages

• Keeps database synchronized.
• Version controls schema changes.
• Easy rollback support.
• Automatic SQL generation.

Time Complexity

Migration Creation : O(1)

Database Update : Depends on schema changes.

============================================================
*/