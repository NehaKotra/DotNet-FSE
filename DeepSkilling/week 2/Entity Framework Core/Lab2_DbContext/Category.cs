using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();
}