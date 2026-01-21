using System.ComponentModel.DataAnnotations;

namespace PointOfSale.DataModel
{
    public class Catagory
    {
        [Key]
        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }
        public bool IsActive { get; set; }
    }
}