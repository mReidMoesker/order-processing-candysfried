using Microsoft.EntityFrameworkCore;
using OrderProcessingSystem.Models;
namespace OrderProcessingSystem.DAL
{
    public class OrdersRepository(OrderProcessingSystemContext context)
    {
        private readonly OrderProcessingSystemContext _context = context;
        public List<Orders> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public Orders GetOrdersById(int id)
        {
            return _context.Orders
                .FirstOrDefault(o => o.OrderId == id)!;
        }

        public void DeleteOrder(Orders order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void CreateOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
