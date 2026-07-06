/*
============================================================
CTS Deep Skilling
Lab 10 - Eager, Lazy and Explicit Loading
============================================================

Objective
---------
Understand different loading strategies for related data.

Loading Types
-------------

1. Eager Loading
   Loads related data along with the main entity.

2. Explicit Loading
   Loads related data only when requested.

3. Lazy Loading
   Loads related data automatically when accessed.

Commands
--------

Install Lazy Loading Package

dotnet add package Microsoft.EntityFrameworkCore.Proxies

Enable Lazy Loading

optionsBuilder.UseLazyLoadingProxies()
              .UseSqlServer("Your_Connection_String");

For Lazy Loading
Navigation properties must be virtual.

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

        Console.WriteLine("======================================");
        Console.WriteLine("Eager Loading");
        Console.WriteLine("======================================");

        var products = await context.Products
            .Include(p => p.Category)
            .ToListAsync();

        foreach (var product in products)
        {
            Console.WriteLine(
                $"{product.Name}  |  ₹{product.Price}  |  {product.Category.Name}");
        }

        Console.WriteLine();

        Console.WriteLine("======================================");
        Console.WriteLine("Explicit Loading");
        Console.WriteLine("======================================");

        var firstProduct = await context.Products.FirstAsync();

        await context.Entry(firstProduct)
            .Reference(p => p.Category)
            .LoadAsync();

        Console.WriteLine(
            $"{firstProduct.Name} belongs to {firstProduct.Category.Name}");

        Console.WriteLine();

        Console.WriteLine("======================================");
        Console.WriteLine("Lazy Loading");
        Console.WriteLine("======================================");

        Console.WriteLine(
            "Requires Microsoft.EntityFrameworkCore.Proxies");

        Console.WriteLine(
            "Navigation properties should be virtual.");

        Console.WriteLine();

        Console.WriteLine("Lab 10 Completed Successfully.");
    }
}

/*
============================================================

Required Changes

Product.cs

public virtual Category Category { get; set; }

Category.cs

public virtual List<Product> Products { get; set; }

============================================================

Expected Output

======================================
Eager Loading
======================================

Laptop | ₹70000 | Electronics

Rice Bag | ₹1200 | Groceries

======================================
Explicit Loading
======================================

Laptop belongs to Electronics

======================================
Lazy Loading
======================================

Requires Microsoft.EntityFrameworkCore.Proxies

Navigation properties should be virtual.

Lab 10 Completed Successfully.

============================================================

Analysis

Eager Loading

Method Used

Include()

Advantages

• Single database query
• Better performance when related data is required.

Time Complexity

O(n)

------------------------------------------------------------

Explicit Loading

Method Used

Reference().LoadAsync()

Advantages

• Loads related data only when needed.

Time Complexity

O(n)

------------------------------------------------------------

Lazy Loading

Advantages

• Automatic loading.
• Cleaner code.

Disadvantages

• Multiple database queries.
• Can reduce performance if overused.

============================================================
*/