using Microsoft.EntityFrameworkCore;
using OrderProcessingSystem.Models;
namespace OrderProcessingSystem.DAL
{
    public class OrdersRepository(OrderProcessingSystemContext context)
    {
        private readonly OrderProcessingSystemContext _context = context;
        public List<Orders> GetOrders()
        {
            return _context.Orders
                .Include(o => o.CustomerName)
                .Include(o => o.OrderDetails)
                .ToList();
        }

        public Orders GetOrdersById(int id)
        {
            Orders? selected = _context.Orders
                .Include(o => o.CustomerName)
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == id);
            return selected;
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
