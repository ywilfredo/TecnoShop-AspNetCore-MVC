using Microsoft.AspNetCore.Mvc;

namespace TecnoShop.Controllers
{
    public class ConctactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
