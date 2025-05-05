using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }

        [Required]
        public string OrderDetails { get; set; }
        public int AmountDue { get; set; }
    }
}