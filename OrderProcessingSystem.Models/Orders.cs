using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace OrderProcessingSystem.Models
{
    public class Orders
    {
        public int OrderId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string OrderDetails { get; set; }
        public int AmountDue { get; set; }
        public bool IsComplete { get; set; }
    }
}