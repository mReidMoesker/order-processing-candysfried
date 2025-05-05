using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.BLL;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Controllers
{
    public class OrdersController(OrdersService service) : Controller
    {
        private readonly OrdersService _service = service;

        // default page shows orders
        public IActionResult Index()
        {
            return View(_service.GetOrders());
        }

        // Creating Orders
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Orders order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            _service.CreateOrder(order);
            return RedirectToAction("Index");
        }

        // Deleting orders
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
