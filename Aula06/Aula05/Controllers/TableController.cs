using Microsoft.AspNetCore.Mvc;

namespace Aula05.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
