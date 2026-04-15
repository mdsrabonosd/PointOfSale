
using System.ComponentModel.DataAnnotations;
namespace PointOfSale.DataModel
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
