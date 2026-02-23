using System.ComponentModel.DataAnnotations;

namespace PointOfSale.DataModel
{
    public class Supplier
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    
}
