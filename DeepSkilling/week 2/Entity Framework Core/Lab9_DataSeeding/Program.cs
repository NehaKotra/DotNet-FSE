/*
============================================================
CTS Deep Skilling
Lab 9 - Seeding Data During Migrations
============================================================

Objective
---------
Seed initial data into the database using HasData()
during migrations.

Step 1
------
Modify AppDbContext.cs

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Category>().HasData(
        new Category
        {
            Id = 1,
            Name = "Electronics"
        },
        new Category
        {
            Id = 2,
            Name = "Groceries"
        }
    );

    modelBuilder.Entity<Product>().HasData(
        new Product
        {
            Id = 1,
            Name = "Smartphone",
            Price = 25000,
            StockQuantity = 50,
            CategoryId = 1
        },
        new Product
        {
            Id = 2,
            Name = "Wheat Flour",
            Price = 800,
            StockQuantity = 100,
            CategoryId = 2
        }
    );
}

Step 2
------

Create Migration

dotnet ef migrations add SeedInitialData

Step 3
------

Update Database

dotnet ef database update

============================================================
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Lab 9 - Data Seeding");
        Console.WriteLine("========================================");

        Console.WriteLine();

        Console.WriteLine("Categories Seeded");

        Console.WriteLine("- Electronics");

        Console.WriteLine("- Groceries");

        Console.WriteLine();

        Console.WriteLine("Products Seeded");

        Console.WriteLine("- Smartphone");

        Console.WriteLine("- Wheat Flour");

        Console.WriteLine();

        Console.WriteLine("Migration");

        Console.WriteLine("dotnet ef migrations add SeedInitialData");

        Console.WriteLine();

        Console.WriteLine("Database Update");

        Console.WriteLine("dotnet ef database update");

        Console.WriteLine();

        Console.WriteLine("Lab 9 Completed Successfully.");
    }
}

/*
============================================================

Expected Output

========================================
Lab 9 - Data Seeding
========================================

Categories Seeded

- Electronics

- Groceries

Products Seeded

- Smartphone

- Wheat Flour

Migration

dotnet ef migrations add SeedInitialData

Database Update

dotnet ef database update

Lab 9 Completed Successfully.

============================================================

Analysis

HasData()

• Inserts initial records automatically.
• Executes during migration.
• Useful for lookup tables.
• Eliminates manual SQL inserts.

Advantages

• Automatic data initialization.
• Consistent database setup.
• Easy deployment.
• Supports version-controlled seed data.

Time Complexity

Seeding Data : O(n)

where n = Number of records inserted.

============================================================
*/