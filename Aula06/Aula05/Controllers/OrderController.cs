using Aula05.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Aula05.Controllers
{
    public class OrderController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public OrderController(IWebHostEnvironment environment)
        {
            _environment = environment;
            _orderRepository = new OrderRepository();
            _customerRepository = new CustomerRepository();
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_orderRepository.RetrieveAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel viewModel = new();
            viewModel.Customers = _customerRepository.RetrieveAll();

            var products = _productRepository.RetrieveAll();
            List<SelectedItem> items = new();

            foreach (var product in products)
            {
                items.Add(new SelectedItem()
                {
                    OrderItem = new()
                    {
                        Product = (Modelo.Product)product
                    }
                });
            }

            viewModel.Items = items;

            return View(viewModel);
        }
    }
}
