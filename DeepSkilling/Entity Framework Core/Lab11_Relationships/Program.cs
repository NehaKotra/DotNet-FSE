/*
============================================================
CTS Deep Skilling
Lab 11 - One-to-One and Many-to-Many Relationships
============================================================

Objective
---------
Configure One-to-One and Many-to-Many relationships
using Entity Framework Core.

One-to-One Relationship
-----------------------
Product  <------>  ProductDetail

Many-to-Many Relationship
-------------------------
Product  <------>  Tag

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

// ====================
// Models
// ====================

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public ProductDetail ProductDetail { get; set; }

    public List<Tag> Tags { get; set; } = new List<Tag>();
}

public class ProductDetail
{
    public int ProductDetailId { get; set; }

    public string WarrantyInfo { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }
}

public class Tag
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();
}

// ====================
// DbContext
// ====================

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductDetail> ProductDetails { get; set; }

    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=RetailInventoryDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One-to-One Relationship

        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductDetail)
            .WithOne(pd => pd.Product)
            .HasForeignKey<ProductDetail>(pd => pd.ProductId);

        // Many-to-Many Relationship

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Tags)
            .WithMany(t => t.Products);
    }
}

// ====================
// Main
// ====================

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("Lab 11");
        Console.WriteLine("Entity Relationships");
        Console.WriteLine("====================================");

        Console.WriteLine();

        Console.WriteLine("One-to-One");

        Console.WriteLine("Product <--> ProductDetail");

        Console.WriteLine();

        Console.WriteLine("Many-to-Many");

        Console.WriteLine("Product <--> Tag");

        Console.WriteLine();

        Console.WriteLine("Entity Framework Core automatically");

        Console.WriteLine("creates the relationship tables.");

        Console.WriteLine();

        Console.WriteLine("Lab 11 Completed Successfully.");
    }
}

/*
============================================================

Expected Output

====================================
Lab 11
Entity Relationships
====================================

One-to-One

Product <--> ProductDetail

Many-to-Many

Product <--> Tag

Entity Framework Core automatically
creates the relationship tables.

Lab 11 Completed Successfully.

============================================================

Analysis

One-to-One

Product
↓

ProductDetail

Each product has exactly one detail.

------------------------------------------------------------

Many-to-Many

Product

↓

Tag

A product can have multiple tags.

A tag can belong to multiple products.

------------------------------------------------------------

Advantages

• Easy relationship mapping.

• Automatic junction table generation.

• Reduces redundant data.

• Improves database normalization.

Time Complexity

Relationship Mapping : O(1)

============================================================
*/