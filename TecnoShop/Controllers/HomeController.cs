using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TecnoShop.Models;
using TecnoShop.ViewModels;

namespace TecnoShop.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IProductoRepositorio _productoRepositorio;

        //instanciar Interfaz de producto y agregar en el constructor de HomeController
        public HomeController(ILogger<HomeController> logger, IProductoRepositorio productoRepositorio)
        {
            _logger = logger;
            _productoRepositorio = productoRepositorio;
        }

        public IActionResult Index()
        {
            ListaProductoViewModel listaProductoViewModel = new ListaProductoViewModel(_productoRepositorio.TodosLosProductos);
            return View(listaProductoViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}