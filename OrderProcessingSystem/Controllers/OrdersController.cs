using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.BLL;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Controllers
{
    public class OrdersController(OrdersService service) : Controller
    {
        private readonly OrdersService _service = service;

        public IActionResult Index()
        {
            return View(_service.GetOrders());
        }

        public IActionResult GetOrders()
        {
            return View(_service.GetOrders);
        }

        [HttpGet]
        public IActionResult DeleteOrders(int id)
        {
            Orders order = _service.GetOrdersById(id);
            if (order != null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult DeleteOrdersConfirmed(int id)
        {
            bool deleted = _service.DeleteOrder(id);
            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
