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

        public async Task<bool> OrderExistsAsync(int id)
            => await _context.Orders.AnyAsync(o => o.OrderId == id);

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = new Orders { OrderId = orderId };
            _context.Orders.Attach(order);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public void CreateOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Orders GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public bool UpdateOrder(Orders order)
        {
            _context.Orders.Update(order);
            return _context.SaveChanges() > 0;
        }

        public bool SaveChanges(Orders order)
        {
            return _context.SaveChanges() > 0;
        }
    }
}
