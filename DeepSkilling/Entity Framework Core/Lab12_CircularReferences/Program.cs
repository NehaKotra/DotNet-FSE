/*
============================================================
CTS Deep Skilling
Lab 12 - Navigating Circular References
============================================================

Objective
---------
Handle circular references in Entity Framework Core
using DTOs and JsonIgnore attribute.

Scenario
--------
A Product belongs to a Category and a Category contains
multiple Products.

Returning both entities directly can create circular
references during JSON serialization.

Solution
--------
1. Use DTOs (Recommended)
2. Use [JsonIgnore] attribute

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
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

//=========================
// Models
//=========================

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public List<Product> Products { get; set; } = new();
}

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}

//=========================
// DTO
//=========================

public class ProductDTO
{
    public string Name { get; set; }

    public string CategoryName { get; set; }
}

//=========================
// DbContext
//=========================

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
        "Server=localhost;Database=RetailInventoryDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}

//=========================
// Main
//=========================

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("===================================");
        Console.WriteLine("Product DTOs");
        Console.WriteLine("===================================\n");

        var productDTOs = await context.Products

            .Include(p => p.Category)

            .Select(p => new ProductDTO
            {
                Name = p.Name,
                CategoryName = p.Category.Name
            })

            .ToListAsync();

        foreach (var item in productDTOs)
        {
            Console.WriteLine(
                $"{item.Name}  -->  {item.CategoryName}");
        }

        Console.WriteLine();

        Console.WriteLine("Circular References Handled Successfully.");
    }
}

/*
============================================================

Expected Output

===================================
Product DTOs
===================================

Laptop --> Electronics

Rice Bag --> Groceries

Circular References Handled Successfully.

============================================================

Analysis

Circular Reference

Category
↓

Products
↓

Category
↓

Products

This causes infinite serialization.

------------------------------------------------------------

Solutions

1. DTO Projection

Select()

Projects only required fields.

2. JsonIgnore

Prevents serialization of navigation properties.

------------------------------------------------------------

Advantages

• Prevents infinite loops.

• Faster API responses.

• Better security.

• Transfers only required data.

Time Complexity

Projection : O(n)

============================================================
*/