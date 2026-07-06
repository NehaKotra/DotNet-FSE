/*
============================================================
CTS Deep Skilling
Lab 15 - Handling Concurrency with RowVersion
============================================================

Objective
---------
Handle concurrency conflicts using RowVersion
in Entity Framework Core.

Steps
-----

1. Add RowVersion property in Product model

[Timestamp]
public byte[] RowVersion { get; set; }

2. Save Changes using Try-Catch

3. Handle DbUpdateConcurrencyException

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
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

//----------------------------------------------------------
// Product Model
//----------------------------------------------------------

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}

//----------------------------------------------------------
// Program
//----------------------------------------------------------

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("======================================");
        Console.WriteLine("Concurrency Handling");
        Console.WriteLine("======================================");

        try
        {
            var product = await context.Products
                .FirstOrDefaultAsync(p => p.Id == 1);

            if (product != null)
            {
                Console.WriteLine("Current Stock : " +
                                  product.StockQuantity);

                product.StockQuantity += 5;

                await context.SaveChangesAsync();

                Console.WriteLine();

                Console.WriteLine("Stock Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Product Not Found.");
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            Console.WriteLine();

            Console.WriteLine("Concurrency conflict detected.");

            Console.WriteLine("Another user has already modified this record.");

            Console.WriteLine("Reload the latest data and try again.");
        }

        Console.WriteLine();

        Console.WriteLine("Lab 15 Completed Successfully.");
    }
}

/*
============================================================

Required Change in Product.cs

using System.ComponentModel.DataAnnotations;

[Timestamp]

public byte[] RowVersion { get; set; }

============================================================

Expected Output

======================================
Concurrency Handling
======================================

Current Stock : 50

Stock Updated Successfully.

Lab 15 Completed Successfully.

If another user updates the same record first:

Concurrency conflict detected.

Another user has already modified this record.

Reload the latest data and try again.

============================================================

Analysis

RowVersion

• Automatically updated by SQL Server.
• Detects concurrent modifications.
• Prevents accidental overwriting of data.

DbUpdateConcurrencyException

• Thrown when another user updates
  the same record before SaveChanges().

Advantages

• Ensures data consistency.
• Prevents lost updates.
• Supports multi-user applications.
• Improves data integrity.

Time Complexity

Update Operation : O(1)

Exception Handling : O(1)

============================================================
*/