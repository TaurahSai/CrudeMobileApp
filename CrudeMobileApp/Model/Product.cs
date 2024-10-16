using System.ComponentModel.DataAnnotations;

namespace CrudeMobileApp.Model
{
    public class Product
    {
        [Key]
        [MaxLength(40)]
        public string ProductId { get; set; }

        [MaxLength(80)]
        public string ProductName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(18)]
        public decimal UnitPrice { get; set; }
    }
}
