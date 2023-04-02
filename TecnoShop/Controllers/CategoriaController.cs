using Microsoft.AspNetCore.Mvc;
using TecnoShop.Models;
using TecnoShop.ViewModels;

namespace TecnoShop.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaCategoria()
        {

            ListaCategoriaViewModel listaCategoriaViewModel = new ListaCategoriaViewModel(_categoriaRepositorio.TodasLasCategorias);
            return View(listaCategoriaViewModel);
        }
    }
}
