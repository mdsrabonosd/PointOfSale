using System.ComponentModel.DataAnnotations;

namespace PointOfSale.DataModel
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupplyerId { get; set; }
        public int CatagoryId { get; set; }
        public double BuyPrice { get; set; }
        public double SalePrice { get; set; }
        public IFormFile Image { get; set; }
        public DateTime ExpireDate { get; set; }



    }
}
