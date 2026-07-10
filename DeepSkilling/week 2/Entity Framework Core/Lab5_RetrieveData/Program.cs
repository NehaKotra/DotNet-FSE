/*
============================================================
CTS Deep Skilling
Lab 5 - Retrieving Data from the Database
============================================================

Objective
---------
Retrieve records from the database using Entity
Framework Core methods.

Methods Used
------------
• ToListAsync()
• FindAsync()
• FirstOrDefaultAsync()

Commands
--------

Build Project
dotnet build

Run Project
dotnet run

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

        Console.WriteLine("=====================================");
        Console.WriteLine("All Products");
        Console.WriteLine("=====================================");

        var products = await context.Products.ToListAsync();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}  {p.Name}  ₹{p.Price}");
        }

        Console.WriteLine();

        Console.WriteLine("=====================================");
        Console.WriteLine("Find Product By ID");
        Console.WriteLine("=====================================");

        var product = await context.Products.FindAsync(1);

        if (product != null)
        {
            Console.WriteLine($"Found : {product.Name} - ₹{product.Price}");
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }

        Console.WriteLine();

        Console.WriteLine("=====================================");
        Console.WriteLine("First Product Price > 50000");
        Console.WriteLine("=====================================");

        var expensive = await context.Products
            .FirstOrDefaultAsync(p => p.Price > 50000);

        if (expensive != null)
        {
            Console.WriteLine($"{expensive.Name} - ₹{expensive.Price}");
        }
        else
        {
            Console.WriteLine("No Expensive Product Found");
        }

        Console.WriteLine();
        Console.WriteLine("Lab 5 Completed Successfully.");
    }
}

/*
============================================================

Expected Output

=====================================
All Products
=====================================

1  Laptop     ₹75000
2  Rice Bag   ₹1200

=====================================
Find Product By ID
=====================================

Found : Laptop - ₹75000

=====================================
First Product Price > 50000
=====================================

Laptop - ₹75000

Lab 5 Completed Successfully.

============================================================

Analysis

Methods

ToListAsync()
--------------
Retrieves all records.

Time Complexity : O(n)

FindAsync()
-----------
Retrieves a record by primary key.

Time Complexity : O(1)

FirstOrDefaultAsync()
---------------------
Retrieves the first record matching a condition.

Time Complexity : O(n)

Advantages

• Easy data retrieval.
• Supports asynchronous execution.
• Integrates LINQ with SQL Server.
• Improves application responsiveness.

============================================================
*/