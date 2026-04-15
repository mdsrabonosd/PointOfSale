
using System.ComponentModel.DataAnnotations; //this data annotation is required
namespace PointOfSale.ViewModel
{
    
    public class CategoryVM
    {
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage = "Category Name is required!")] // this is data anotation for error message
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}