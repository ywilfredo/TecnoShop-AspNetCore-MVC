using Microsoft.AspNetCore.Mvc;
using TecnoShop.Models;
using TecnoShop.ViewModels;

namespace TecnoShop.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController( ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }
        
        public IActionResult Index()
        {

            //ListaCategoriaViewModel listaCategoriaViewModel = new ListaCategoriaViewModel(_categoriaRepositorio.TodasLasCategorias);
            //return View(listaCategoriaViewModel);
            IEnumerable<Categoria> categorias = _categoriaRepositorio.TodasLasCategorias;
            return View(categorias);

        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult CrearCategoria()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CrearCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepositorio.CrearCategoria(categoria);
                TempData["mensaje"] = "La categoria se creó correctamente";
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        

        public IActionResult CategoriaCreada()
        {
            ViewBag.MensajeCategoriaCreada = "¡Gracias por agregar una nueva categoría para sus productos!";
            return View();
        }


        public IActionResult DetalleCategoria(int id)
        {
            Categoria? categoria = _categoriaRepositorio.ObtenerCategoria(id);
            return View(categoria);
        }

        public IActionResult EditarCategoria(int id)
        {
            Categoria? categoria = _categoriaRepositorio.ObtenerCategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult EditarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepositorio.EditarCategoria(categoria);
                TempData["mensaje"] = "La categoria se actualizó correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }


        public IActionResult EliminarCategoria(int id)
        {
            Categoria? categoria = _categoriaRepositorio.ObtenerCategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult EliminarCategoria(Categoria categoria)
        {
           
             _categoriaRepositorio.EliminarCategoria(categoria);
            TempData["mensaje"] = "La categoria se eliminó correctamente";
            return RedirectToAction("Index");
        }

    }
}
