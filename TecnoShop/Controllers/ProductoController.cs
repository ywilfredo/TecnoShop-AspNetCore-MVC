using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecnoShop.Models;
using TecnoShop.ViewModels;
using static NuGet.Packaging.PackagingConstants;

namespace TecnoShop.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMarcaRepositorio _marcaRepositorio;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductoController(IProductoRepositorio productoRepositorio, ICategoriaRepositorio categoriaRepositorio, IMarcaRepositorio marcaRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            _productoRepositorio = productoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _marcaRepositorio = marcaRepositorio;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //IEnumerable<Producto> productos = _productoRepositorio.TodosLosProductos.ToList();
            //return View(productos);

            ListaProductoViewModel listaProductoViewModel = new ListaProductoViewModel(_productoRepositorio.TodosLosProductos, "Gaming");
            return View(listaProductoViewModel);

            //ProductoViewModel ProductoViewModel = new ProductoViewModel(_productoRepositorio.TodosLosProductos, _categoriaRepositorio.TodasLasCategorias, _marcaRepositorio.TodasLasMarcas);
            //return View(ProductoViewModel);

        }

        public IActionResult ListaProducto()
        {

            ListaProductoViewModel listaProductoViewModel = new ListaProductoViewModel(_productoRepositorio.TodosLosProductos, "Gaming");
            return View(listaProductoViewModel);
        }

        public IActionResult DescripcionProducto(int id) // el id tiene que se er mismo que en la vista. 
        {
            var producto = _productoRepositorio.ObtenerProductoPorId(id);
            if (producto == null)
                return NotFound();
            return View(producto);
        }

        public IActionResult DetalleProducto(int id)  
        {
            var producto = _productoRepositorio.ObtenerProductoPorId(id);
            if (producto == null)
                return NotFound();
            return View(producto);
        }


        public IActionResult CrearProducto()
        {
            ProductCreateViewModel productCreateViewModel = new ProductCreateViewModel();

            //Cargar las categorias de la base de datos al ViewModel
            List<SelectListItem> categorias = _categoriaRepositorio.TodasLasCategorias
                .OrderBy(c => c.Nombre)
                     .Select(c =>
                      new SelectListItem
                      {
                          Value = c.CategoriaId.ToString(),
                          Text = c.Nombre
                      }).ToList();
            productCreateViewModel.CategoriasItems = categorias;

            //Cargar las marcas de la base de datos al ViewModel
            List<SelectListItem> marcas = _marcaRepositorio.TodasLasMarcas
                .OrderBy(m => m.Nombre)
                     .Select(m =>
                      new SelectListItem
                      {
                          Value = m.MarcaId.ToString(),
                          Text = m.Nombre
                      }).ToList();
            productCreateViewModel.MarcasItems = marcas;

            return View(productCreateViewModel);
        }
        [HttpPost]
        public  async Task<IActionResult> CrearProducto(ProductCreateViewModel productViewModel)
        {

           
            if (ModelState.IsValid)
            {
                if (productViewModel.ImageFile != null)
                {
                    productViewModel.ImagenUrl = SubirArchivo(productViewModel);
                }

                //GuardarProducto
                int id = await _productoRepositorio.CrearProducto(productViewModel);
                if(id > 0)
                {
                    TempData["mensaje"] = "El producto se creó correctamente";
                    return RedirectToAction("Index");
                }
                
            }
            return View(productViewModel);

        }




        private string SubirArchivo(ProductCreateViewModel productViewModel)
        {
            string fileName = null;
            if (productViewModel.ImageFile != null)
            {
                string folder = "images";
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                fileName = Guid.NewGuid().ToString() + "-" + productViewModel.ImageFile.FileName;
                string filePath = Path.Combine(serverFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    productViewModel.ImageFile.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        //Guardar Archivo
        private string GuardarAchivo(ProductCreateViewModel productViewModel)
        {
            string folder = null;
            if (productViewModel.ImageFile != null)
            {
                folder = "images/"; //fileName
                folder += Guid.NewGuid().ToString() + "_" + productViewModel.ImageFile.FileName;
                //productViewModel.ImagenUrl = "/"+folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                productViewModel.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            return folder;
        }


        public IActionResult EditarProducto(int id)
        {
            Producto? producto = _productoRepositorio.ObtenerProductoPorId(id);

            ProductCreateViewModel productCreateViewModel = new ProductCreateViewModel
            {
                Nombre = producto.Nombre,
                Especificaciones = producto.Especificaciones,
                Precio = producto.Precio,
                Disponible = producto.Disponible,
                Destacado = producto.Destacado,
                CategoriaId = producto.CategoriaId,
                MarcaId = producto.MarcaId,
                ImagenUrl = producto.ImagenUrl
            };

            //Cargar las categorias de la base de datos al ViewModel
            List<SelectListItem> categorias = _categoriaRepositorio.TodasLasCategorias
                .OrderBy(c => c.Nombre)
                     .Select(c =>
                      new SelectListItem
                      {
                          Value = c.CategoriaId.ToString(),
                          Text = c.Nombre
                      }).ToList();

            productCreateViewModel.CategoriasItems = categorias;

            //Cargar las marcas de la base de datos al ViewModel
            List<SelectListItem> marcas = _marcaRepositorio.TodasLasMarcas
                .OrderBy(m => m.Nombre)
                     .Select(m =>
                      new SelectListItem
                      {
                          Value = m.MarcaId.ToString(),
                          Text = m.Nombre
                      }).ToList();
            productCreateViewModel.MarcasItems = marcas;

            return View(productCreateViewModel);

        }

        //[HttpPost]
        //public IActionResult EditarProducto(ProductCreateViewModel productViewModel)
        //{
        //    var producto = new Producto();
        //    if (ModelState.IsValid)
        //    {
        //        string nombreArchivo = SubirArchivo(productViewModel);

        //        producto.Nombre = productViewModel.Nombre;
        //        producto.Especificaciones = productViewModel.Especificaciones;
        //        producto.Precio = Convert.ToDecimal(productViewModel.Precio);
        //        producto.Disponible = productViewModel.Disponible;
        //        producto.Destacado = productViewModel.Destacado;
        //        producto.ImagenUrl = nombreArchivo;
        //        producto.MarcaId = productViewModel.MarcaId;
        //        producto.CategoriaId = productViewModel.CategoriaId;

        //        //GuardarProducto
        //        _productoRepositorio.EditarProducto(producto);
        //        TempData["mensaje"] = "El producto se actualizó correctamente";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(producto);
        //}
    }
}


//Guardar imagen en el wwwroot/images

//string wwwrootPath = _webHostEnvironment.WebRootPath;
//string fileName = Path.GetFileNameWithoutExtension(productViewModel.ImageFile.FileName);
//string extension = Path.GetExtension(productViewModel.ImageFile.FileName);
//productViewModel.Producto.ImagenUrl = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//string path = Path.Combine(wwwrootPath + "/images/", fileName);
//using (var fileStream = new FileStream(path,FileMode.Create))
//{
//    productViewModel.ImageFile.CopyTo(fileStream);
//}
