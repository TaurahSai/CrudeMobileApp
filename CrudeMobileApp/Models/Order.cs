using CrudeMobileApp.Models;
using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudeMobileApp.Model
{
    public class Order
    {
        [Key]
        [AutoIncrement]
        public int OrderId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public string ShippingName { get; set; }
        public string ShippingAddress { get; set;}
        public string ShippingCity { get; set;}
        public string  ShippingRegion { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set;}
        public string ShippingPhone { get; set;}
        public Customer Customer { get; set; }
    }
}