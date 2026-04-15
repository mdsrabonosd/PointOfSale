using PointOfSale.DataModel;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; }

    public bool IsActive { get; set; }

    // এই ক্যাটাগরির আন্ডারে অনেকগুলো প্রোডাক্ট থাকতে পারে
    public virtual ICollection<Product> Products { get; set; }
}