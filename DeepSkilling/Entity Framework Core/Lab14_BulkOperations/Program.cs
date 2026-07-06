/*
============================================================
CTS Deep Skilling
Lab 14 - Batch Processing and Bulk Operations
============================================================

Objective
---------
Perform batch updates using EFCore.BulkExtensions
for better performance.

Methods Used
------------
• BulkUpdateAsync()
• SaveChangesAsync()

Commands
--------

Install Package

dotnet add package EFCore.BulkExtensions

Build Project

dotnet build

Run Project

dotnet run

============================================================
*/

using EFCore.BulkExtensions;
using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("======================================");
        Console.WriteLine("Bulk Update Operation");
        Console.WriteLine("======================================");

        var products = context.Products.ToList();

        foreach (var product in products)
        {
            product.StockQuantity += 10;
        }

        await context.BulkUpdateAsync(products);

        Console.WriteLine();

        Console.WriteLine("Stock Updated Successfully.");

        Console.WriteLine();

        Console.WriteLine("Updated Product List");

        foreach (var product in context.Products)
        {
            Console.WriteLine(
                $"{product.Name} | Stock : {product.StockQuantity}");
        }

        Console.WriteLine();

        Console.WriteLine("Lab 14 Completed Successfully.");
    }
}

/*
============================================================

Expected Output

======================================
Bulk Update Operation
======================================

Stock Updated Successfully.

Updated Product List

Laptop | Stock : 60
Rice Bag | Stock : 110

Lab 14 Completed Successfully.

============================================================

Analysis

BulkUpdateAsync()

• Updates multiple records together.
• Much faster than SaveChangesAsync()
  for large datasets.

Comparison

SaveChangesAsync()

• Executes multiple UPDATE statements.
• Slower for thousands of records.

BulkUpdateAsync()

• Executes batch update.
• Better performance.
• Reduces database round trips.

------------------------------------------------------------

Advantages

• High performance.
• Suitable for large datasets.
• Reduces execution time.
• Efficient database communication.

Time Complexity

Bulk Update : O(n)

where n = Number of records updated.

============================================================
*/