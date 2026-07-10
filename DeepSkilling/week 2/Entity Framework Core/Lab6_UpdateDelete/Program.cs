/*
============================================================
CTS Deep Skilling
Lab 6 - Updating and Deleting Records
============================================================

Objective
---------
Update and delete records using Entity Framework Core.

Methods Used
------------
• FirstOrDefaultAsync()
• SaveChangesAsync()
• Remove()

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

        Console.WriteLine("========== Updating Product ==========\n");

        var product = await context.Products
            .FirstOrDefaultAsync(p => p.Name == "Laptop");

        if (product != null)
        {
            Console.WriteLine($"Old Price : ₹{product.Price}");

            product.Price = 70000;

            await context.SaveChangesAsync();

            Console.WriteLine($"New Price : ₹{product.Price}");
            Console.WriteLine("Product Updated Successfully.");
        }
        else
        {
            Console.WriteLine("Laptop Not Found.");
        }

        Console.WriteLine("\n========== Deleting Product ==========\n");

        var toDelete = await context.Products
            .FirstOrDefaultAsync(p => p.Name == "Rice Bag");

        if (toDelete != null)
        {
            context.Products.Remove(toDelete);

            await context.SaveChangesAsync();

            Console.WriteLine("Rice Bag Deleted Successfully.");
        }
        else
        {
            Console.WriteLine("Rice Bag Not Found.");
        }

        Console.WriteLine("\n========== Remaining Products ==========\n");

        var products = await context.Products.ToListAsync();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}  {p.Name}  ₹{p.Price}");
        }

        Console.WriteLine("\nLab 6 Completed Successfully.");
    }
}

/*
============================================================

Expected Output

========== Updating Product ==========

Old Price : ₹75000
New Price : ₹70000
Product Updated Successfully.

========== Deleting Product ==========

Rice Bag Deleted Successfully.

========== Remaining Products ==========

1  Laptop  ₹70000

Lab 6 Completed Successfully.

============================================================

Analysis

Update Operation
----------------
• Retrieve product using FirstOrDefaultAsync()
• Modify property
• SaveChangesAsync()

Delete Operation
----------------
• Retrieve product
• Remove()
• SaveChangesAsync()

Time Complexity

Update : O(n)

Delete : O(n)

Advantages

• Easy CRUD operations.
• Automatic SQL generation.
• Asynchronous database operations.
• Better maintainability.

============================================================
*/