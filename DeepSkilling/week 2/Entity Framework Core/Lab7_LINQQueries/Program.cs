/*
============================================================
CTS Deep Skilling
Lab 7 - Writing Queries with LINQ
============================================================

Objective
---------
Use LINQ queries in Entity Framework Core to
filter, sort and project data.

Methods Used
------------
• Where()
• OrderByDescending()
• Select()
• ToListAsync()

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
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("======================================");
        Console.WriteLine("Products with Price > 1000");
        Console.WriteLine("======================================");

        var filteredProducts = await context.Products
            .Where(p => p.Price > 1000)
            .OrderByDescending(p => p.Price)
            .ToListAsync();

        foreach (var product in filteredProducts)
        {
            Console.WriteLine($"{product.Name} - ₹{product.Price}");
        }

        Console.WriteLine();

        Console.WriteLine("======================================");
        Console.WriteLine("Projecting Products into DTO");
        Console.WriteLine("======================================");

        var productDTOs = await context.Products
            .Select(p => new
            {
                p.Name,
                p.Price
            })
            .ToListAsync();

        foreach (var item in productDTOs)
        {
            Console.WriteLine($"{item.Name} - ₹{item.Price}");
        }

        Console.WriteLine();

        Console.WriteLine("Lab 7 Completed Successfully.");
    }
}

/*
============================================================

Expected Output

======================================
Products with Price > 1000
======================================

Laptop - ₹70000
Rice Bag - ₹1200

======================================
Projecting Products into DTO
======================================

Laptop - ₹70000
Rice Bag - ₹1200

Lab 7 Completed Successfully.

============================================================

Analysis

Where()
-------
Filters records based on a condition.

OrderByDescending()
-------------------
Sorts records in descending order.

Select()
--------
Projects only required columns.

Advantages

• Simple syntax
• Strongly typed queries
• Automatic SQL generation
• Better readability

Time Complexity

Where()              O(n)

OrderByDescending()  O(n log n)

Select()             O(n)

============================================================
*/