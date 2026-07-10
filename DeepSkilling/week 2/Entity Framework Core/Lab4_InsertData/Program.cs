/*
============================================================
CTS Deep Skilling
Lab 4 - Inserting Initial Data into the Database
============================================================

Objective
---------
Insert categories and products into the SQL Server
database using Entity Framework Core.

Commands
--------

Build Project
dotnet build

Run Project
dotnet run

Verify Database
Open SQL Server Management Studio (SSMS)
or Azure Data Studio and check:

• Categories Table
• Products Table

============================================================
*/

using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        var electronics = new Category
        {
            Name = "Electronics"
        };

        var groceries = new Category
        {
            Name = "Groceries"
        };

        await context.Categories.AddRangeAsync(
            electronics,
            groceries
        );

        var product1 = new Product
        {
            Name = "Laptop",
            Price = 75000,
            Category = electronics
        };

        var product2 = new Product
        {
            Name = "Rice Bag",
            Price = 1200,
            Category = groceries
        };

        await context.Products.AddRangeAsync(
            product1,
            product2
        );

        await context.SaveChangesAsync();

        Console.WriteLine("=====================================");
        Console.WriteLine("Data Inserted Successfully");
        Console.WriteLine("=====================================");

        Console.WriteLine("Categories Added");
        Console.WriteLine("- Electronics");
        Console.WriteLine("- Groceries");

        Console.WriteLine();

        Console.WriteLine("Products Added");
        Console.WriteLine("- Laptop");
        Console.WriteLine("- Rice Bag");
    }
}

/*
============================================================

Expected Output

=====================================
Data Inserted Successfully
=====================================

Categories Added
- Electronics
- Groceries

Products Added
- Laptop
- Rice Bag

============================================================

Analysis

Methods Used

• AddRangeAsync()
• SaveChangesAsync()

Advantages

• Asynchronous operations improve performance.
• Multiple records can be inserted efficiently.
• Reduces database calls.

Time Complexity

Insertion : O(n)

where n = Number of records inserted.

============================================================
*/