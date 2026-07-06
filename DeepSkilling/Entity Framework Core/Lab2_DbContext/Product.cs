using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public int StockQuantity { get; set; }
public class Product
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}