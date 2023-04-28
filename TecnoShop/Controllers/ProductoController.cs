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
            var productoVM = _productoRepositorio.ObtenerProducto(id);
            productoVM.CategoriasItems = CargarCategoriasItems();
            productoVM.MarcasItems = CargarMarcasItems();
            
            foreach(var cate in _categoriaRepositorio.TodasLasCategorias)
            {
               if(productoVM.CategoriaId == cate.CategoriaId)
                {
                    productoVM.NombreCategoria = cate.Nombre;
                }
            }
            foreach (var marca in _marcaRepositorio.TodasLasMarcas)
            {
                if (productoVM.MarcaId == marca.MarcaId)
                {
                    productoVM.NombreMarca = marca.Nombre;
                }
            }
            if (productoVM.Disponible)
                productoVM.EstaDisponible = "Sí";
            else productoVM.EstaDisponible = "No";

            if (productoVM.Destacado)
                productoVM.EsDestacado = "Sí";
            else productoVM.EsDestacado = "No";
                
            return View(productoVM);
        }


        public IActionResult CrearProducto()
        {
            ProductoViewModel productCreateViewModel = new ProductoViewModel();

            
            productCreateViewModel.CategoriasItems = CargarCategoriasItems();
            productCreateViewModel.MarcasItems = CargarMarcasItems();

            return View(productCreateViewModel);
        }
        [HttpPost]
        public  async Task<IActionResult> CrearProducto(ProductoViewModel productoViewModel)
        {

           
            if (ModelState.IsValid)
            {
                if (productoViewModel.ArchivoImagen != null)
                {
                    //productViewModel.ImagenUrl = GuardarImagen(productViewModel);
                    string folder = "images/";
                    folder += Guid.NewGuid().ToString() + "_" + productoViewModel.ArchivoImagen.FileName;
                    productoViewModel.ImagenUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await productoViewModel.ArchivoImagen.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    
                }

                int id = await _productoRepositorio.CrearProducto(productoViewModel);
                if(id > 0)
                {
                    TempData["mensaje"] = "El producto se creó correctamente";
                    return RedirectToAction("Index");
                }
                
            }
            return View(productoViewModel);

        }


        private string GuardarImagen(ProductoViewModel productViewModel)
        {
            string fileName = null;
            if (productViewModel.ArchivoImagen != null)
            {
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath,"images");
                fileName = Guid.NewGuid().ToString() + "-" + productViewModel.ArchivoImagen.FileName;
                string filePath = Path.Combine(serverFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    productViewModel.ArchivoImagen.CopyTo(fileStream);
                }
            }
            return fileName;
        }



        public IActionResult EditarProducto(int id)
        {
            var productoVM = _productoRepositorio.ObtenerProducto(id);
            productoVM.CategoriasItems = CargarCategoriasItems();
            productoVM.MarcasItems = CargarMarcasItems();

            return View(productoVM);

        }

        //[HttpPost]
        //public IActionResult EditarProductoAntes(ProductCreateViewModel productViewModel)
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



        //Obtener MarcasItems
        public List<SelectListItem> CargarMarcasItems()
        {
            List<SelectListItem> marcas = _marcaRepositorio.TodasLasMarcas
                .OrderBy(m => m.Nombre)
                     .Select(m =>
                      new SelectListItem
                      {
                          Value = m.MarcaId.ToString(),
                          Text = m.Nombre
                      }).ToList();
            return marcas;
        }

        //Obtener CategoriasItems
        public List<SelectListItem> CargarCategoriasItems()
        {
            List<SelectListItem> categorias = _categoriaRepositorio.TodasLasCategorias
               .OrderBy(c => c.Nombre)
                    .Select(c =>
                     new SelectListItem
                     {
                         Value = c.CategoriaId.ToString(),
                         Text = c.Nombre
                     }).ToList();
            return categorias;
        }
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
