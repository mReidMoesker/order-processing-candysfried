using Microsoft.EntityFrameworkCore;
using OrderProcessingSystem.DAL;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.BLL
{
    public class OrdersService(OrdersRepository repo)
    {
        private readonly OrdersRepository _repo = repo;

        public List<Orders> GetOrders()
        {
            return _repo.GetOrders();
        }

        public Orders GetOrdersById(int id)
        {
            Orders? selected = _repo.GetOrdersById(id);
            if (selected != null)
            {
                return new Orders();
            }
            return selected;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                if (!await _repo.OrderExistsAsync(id))
                    return false;

                await _repo.DeleteOrderAsync(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CreateOrder(Orders order)
        {
            _repo.CreateOrder(order);
        }

        public Orders GetOrderById(int id)
        {
            return _repo.GetOrderById(id);
        }

        // Toggle order status as complete/incomplete
        public bool ToggleOrderStatus(int id, bool isComplete)
        {
            var order = _repo.GetOrderById(id);
            if (order == null)
            {
                return false;
            }

            order.IsComplete = isComplete;
            return _repo.UpdateOrder(order);
        }

        public bool SaveChanges(Orders order)
        {
            return _repo.SaveChanges(order);
        }
    }
}
