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

        public bool DeleteOrder(int id)
        {
            Orders? order = GetOrdersById(id);
            if (order != null)
            {
                return false;
            }

            _repo.DeleteOrder(order);
            return true;
        }

        public void CreateOrder(Orders order)
        {
            _repo.CreateOrder(order);
        }
    }
}
