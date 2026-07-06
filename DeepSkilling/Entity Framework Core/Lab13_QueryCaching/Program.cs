/*
============================================================
CTS Deep Skilling
Lab 13 - Query Caching and Tracking Behavior
============================================================

Objective
---------
Optimize read-only queries using AsNoTracking()
and improve query performance using compiled queries.

Methods Used
------------
• AsNoTracking()
• EF.CompileAsyncQuery()

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
    // Compiled Query

    static readonly Func<AppDbContext, decimal, IAsyncEnumerable<Product>>
        ExpensiveProductsQuery =
        EF.CompileAsyncQuery(
            (AppDbContext context, decimal price) =>
                context.Products.Where(p => p.Price > price)
        );

    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("=====================================");
        Console.WriteLine("AsNoTracking()");
        Console.WriteLine("=====================================\n");

        var products = await context.Products
            .AsNoTracking()
            .ToListAsync();

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name} - ₹{product.Price}");
        }

        Console.WriteLine();

        Console.WriteLine("=====================================");
        Console.WriteLine("Compiled Query");
        Console.WriteLine("=====================================\n");

        await foreach (var product in ExpensiveProductsQuery(context, 10000))
        {
            Console.WriteLine($"{product.Name} - ₹{product.Price}");
        }

        Console.WriteLine();

        Console.WriteLine("Lab 13 Completed Successfully.");
    }
}

/*
============================================================

Expected Output

=====================================
AsNoTracking()
=====================================

Laptop - ₹70000
Rice Bag - ₹1200

=====================================
Compiled Query
=====================================

Laptop - ₹70000

Lab 13 Completed Successfully.

============================================================

Analysis

AsNoTracking()

• Improves performance for read-only queries.
• Entity Framework does not track changes.
• Uses less memory.

------------------------------------------------------------

Compiled Query

• Query is compiled once.
• Reused multiple times.
• Faster execution.

------------------------------------------------------------

Advantages

• Faster read operations.
• Reduced memory usage.
• Better performance for frequent queries.

Time Complexity

AsNoTracking()      O(n)

Compiled Query      O(n)

============================================================
*/