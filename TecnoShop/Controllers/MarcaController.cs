using Microsoft.AspNetCore.Mvc;
using TecnoShop.Models;
using TecnoShop.ViewModels;

namespace TecnoShop.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public MarcaController(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaMarca()
        {

            ListaMarcaViewModel listaMarcaViewModel = new ListaMarcaViewModel(_marcaRepositorio.TodasLasMarcas);
            return View(listaMarcaViewModel);
        }
    }
}
