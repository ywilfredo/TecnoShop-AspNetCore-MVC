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

            ListaMarcaViewModel listaMarcaViewModel = new ListaMarcaViewModel(_marcaRepositorio.TodasLasMarcas);
            return View(listaMarcaViewModel);
        }

        public IActionResult CrearMarca()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CrearMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _marcaRepositorio.CrearMarca(marca);
                return RedirectToAction("MarcaCreada");
            }

            return View(marca);

        }
        public IActionResult MarcaCreada()
        {
            ViewBag.MensajeMarcaCreada = "¡Gracias por agregar una nueva marca para sus productos!";
            return View();
        }
    }
}
