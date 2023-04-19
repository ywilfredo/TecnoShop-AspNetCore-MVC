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

            IEnumerable<Marca> marcas = _marcaRepositorio.TodasLasMarcas();
            return View(marcas);
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
                TempData["mensaje"] = "La marca se creó correctamente";
                return RedirectToAction("Index");
            }

            return View(marca);

        }

        public IActionResult DetalleMarca(int id)
        {
            Marca? marca = _marcaRepositorio.ObtenerMarca(id);
            return View(marca);
        }

        public IActionResult EditarMarca(int id)
        {
            Marca? marca = _marcaRepositorio.ObtenerMarca(id);
            return View(marca);
        }

        [HttpPost]
        public IActionResult EditarMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _marcaRepositorio.EditarMarca(marca);
                TempData["mensaje"] = "La marca se actualizó correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }


        public IActionResult EliminarMarca(int id)
        {
            Marca? marca = _marcaRepositorio.ObtenerMarca(id);
            return View(marca);
        }

        [HttpPost]
        public IActionResult EliminarMarca(Marca marca)
        {

            _marcaRepositorio.EliminarMarca(marca);
            TempData["mensaje"] = "La marca se eliminó correctamente";
            return RedirectToAction("Index");
        }
    }
}
