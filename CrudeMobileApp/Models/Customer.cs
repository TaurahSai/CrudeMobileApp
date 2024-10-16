using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CrudeMobileApp.Models
{
    public class Customer
    {
        [Key]
        [MaxLength(20)]
        public string CustomerId { get; set; }

        [MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string ContactName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Region { get; set; }

        [MaxLength(20)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(20)]
        [AllowNull]
        public string Phone { get; set; }
    }
}
