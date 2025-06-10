using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;

namespace Aula05.Controllers
{
    public class CustomerControleler : Controller
    {
        private CustomerRepositorycs _customerRepository;

        public CustomerControleler()
        {
            _customerRepository = new CustomerRepositorycs(); 
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers = _customerRepository.RetrieveAll();
            return View(customers);
        }

        [HttpPost]
        
        public IActionResult Create(Customer c)
        {
            _customerRepository.Save(c);
            return View();
        }

        [HttpPost]
        public IActionResult Create ()
        {
            return View();
        }
    }
}
