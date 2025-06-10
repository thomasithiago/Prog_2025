using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;
using System.IO;

namespace Aula05.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private CustomerRepository _customerRepository;

        public CustomerController(
            IWebHostEnvironment environment
        )
        {
            _customerRepository = new CustomerRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers =
                _customerRepository.RetrieveAll();

            return View(customers);
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            _customerRepository.Save(c);

            List<Customer> customers =
                _customerRepository.RetrieveAll();

            return View("Index", customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                fileContent +=
                    $"{c.Id};{c.Name};{c.HomeAddress!.Id};{c.HomeAddress.City};{c.HomeAddress.State};{c.HomeAddress.Country};{c.HomeAddress.Street1};{c.HomeAddress.Street2};{c.HomeAddress.PostalCode};{c.HomeAddress.AddressType}\n";
            }

            SaveFile(fileContent, "DelimitedFile.txt");

            return View();
        }

        [HttpPost]
        public IActionResult ExportFixedFile()
        {
             string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                fileContent +=
                    String.Format("{0:5}", c.Id) +
                    String.Format("(0:64}", c.Name) +
                    String.Format("(0:5}", c.HomeAddress!.Id) +
                    String.Format("(0:32}", c.HomeAddress!.City) +
                    String.Format("(0:2}", c.HomeAddress!.State) +
                    String.Format("(0:32}", c.HomeAddress!.Country) +
                    String.Format("(0:64}", c.HomeAddress!.Street1) +
                    String.Format("(0:64}", c.HomeAddress!.Street2) +
                    String.Format("(0:9}", c.HomeAddress!.PostalCode) +
                    String.Format("(0:16}", c.HomeAddress!.AddressType);


                fileContent +=
                    $"{c.Id};{c.Name};{c.HomeAddress!.Id};{c.HomeAddress.City};{c.HomeAddress.State};{c.HomeAddress.Country};{c.HomeAddress.Street1};{c.HomeAddress.Street2};{c.HomeAddress.PostalCode};{c.HomeAddress.AddressType}\n";
            }

            SaveFile(fileContent, "DelimitedFile.txt");

            return RedirectToAction("Index");
        }
        private bool SaveFile(string content, string fileName)
        {
            bool ret = true;

            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName))
                return false;

            var path = Path.Combine(
                environment.WebRootPath,
                "TextFiles"
            );

            try
            {


                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                var filepath = Path.Combine(
                path,
                fileName
                 );

                if (!System.IO.File.Exists(filepath))
                {
                    using (StreamWriter sw = System.IO.File.CreateText(filepath))
                    {
                        sw.Write(content);
                    }
                }
            }
            catch (IOException ioex)
            {
                string msg = ioex.Message;
                ret = false;
                //throw ioEx;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
                //throw ex;
            }

            return ret;
        }

    }
}