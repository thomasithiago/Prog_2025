using Aula05.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SeuProjeto.ViewModels;

namespace Aula05.Controllers
{
    public class OrderController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public OrderController(IWebHostEnvironment environment)
        {
            this.environment = environment;
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
            var viewModel = new OrderViewModel();

            // Recupera os clientes
            viewModel.Customers = _customerRepository.RetrieveAll();

            // Recupera os produtos
            var produtos = _productRepository.RetrieveAll();

            // Cria a lista de SelectedItem com os produtos
            List<SelectedItem> selectedItems = new();
            foreach (var produto in produtos)
            {
                selectedItems.Add(new SelectedItem
                {
                    OrderItem = new OrderItemViewModel
                    {
                        Product = produto,
                        Quantity = 0,
                        Selected = false
                    }
                });
            }

            
            viewModel.SelectedItems = selectedItems;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel viewModel)
        {
            
            return View(viewModel);
        }
    }
}
