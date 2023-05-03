using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
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

        //Index con paginacion
        public IActionResult Index(int pg = 1)
        {
            
            List<Producto> products = _productoRepositorio.TodosLosProductos.ToList();
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;
            int recsCount = products.Count;
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = products.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            //return View(products);
            return View(data);
        }



        public IActionResult ListaProducto()
        {

            ListaProductoViewModel listaProductoViewModel = new ListaProductoViewModel(_productoRepositorio.TodosLosProductos);
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

            foreach (var cate in _categoriaRepositorio.TodasLasCategorias)
            {
                if (productoVM.CategoriaId == cate.CategoriaId)
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
        public async Task<IActionResult> CrearProducto(ProductoViewModel productoViewModel)
        {


            if (ModelState.IsValid)
            {
                if (productoViewModel.ArchivoImagen != null)
                {
                    
                    //Guardar imagen en ~/images/nombre_image.jpg
                    string folder = "images/";
                    folder += Guid.NewGuid().ToString() + "_" + productoViewModel.ArchivoImagen.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    using( var fileStream = new FileStream(serverFolder, FileMode.Create))
                    {
                        await productoViewModel.ArchivoImagen.CopyToAsync(fileStream);
                    }
                    
                    
                    //asignar la direccion url al viewmodel
                    productoViewModel.ImagenUrl = "/" + folder;

                }

                int id = await _productoRepositorio.CrearProducto(productoViewModel);
                if (id > 0)
                {
                    TempData["mensaje"] = "El producto se creó correctamente";
                    return RedirectToAction("Index");
                }

            }
            return View(productoViewModel);

        }

        public IActionResult EditarProducto(int id)
        {
            var productoVM = _productoRepositorio.ObtenerProducto(id);
            productoVM.CategoriasItems = CargarCategoriasItems();
            productoVM.MarcasItems = CargarMarcasItems();
            productoVM.PrecioP = Convert.ToInt32(productoVM.Precio);

            return View(productoVM);

        }

        [HttpPost]
        public IActionResult EditarProducto(ProductoViewModel productoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (productoViewModel.ArchivoImagen != null) 
                {
                    if (productoViewModel.ImagenUrl != null)
                    {
                        //obtener solo el nombre de la imagen
                        char[] carpeta = { '/', 'i', 'm', 'a', 'g', 'e', 's','/'};
                        productoViewModel.nombreImagen = productoViewModel.ImagenUrl.TrimStart(carpeta);

                        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", productoViewModel.nombreImagen);
                        if (System.IO.File.Exists(imagePath))
                            System.IO.File.Delete(imagePath);
                    }

                    //Guardar imagen en ~/images/nombre_image.jpg
                    string folder = "images/";
                    folder += Guid.NewGuid().ToString() + "_" + productoViewModel.ArchivoImagen.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    //productoViewModel.ArchivoImagen.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                    {
                        productoViewModel.ArchivoImagen.CopyToAsync(fileStream);
                    }

                    //asignar la direccion url al viewmodel
                    productoViewModel.ImagenUrl = "/" + folder;

                }

                //Guardar cambios
                _productoRepositorio.EditarProducto(productoViewModel);
                TempData["mensaje"] = "El producto se actualizó correctamente";
                return RedirectToAction(nameof(Index));
            }
               
            return View(productoViewModel);
        }

        public IActionResult EliminarProducto(int id)
        {
            var productoVM = _productoRepositorio.ObtenerProducto(id);
            productoVM.CategoriasItems = CargarCategoriasItems();
            productoVM.MarcasItems = CargarMarcasItems();

            foreach (var cate in _categoriaRepositorio.TodasLasCategorias)
            {
                if (productoVM.CategoriaId == cate.CategoriaId)
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
        [HttpPost]
        public IActionResult EliminarProducto(ProductoViewModel productoViewModel)
        {
            //eliminar la imagen que tiene y luego reemplazarla por una nueva imagen
            char[] carpeta = { '/', 'i', 'm', 'a', 'g', 'e', 's', '/' };
            productoViewModel.nombreImagen = productoViewModel.ImagenUrl.TrimStart(carpeta);

            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", productoViewModel.nombreImagen);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            Producto? producto = _productoRepositorio.ObtenerProductoPorId(productoViewModel.ProductoId);
            _productoRepositorio.EliminarProducto(producto);
            TempData["mensaje"] = "El producto se eliminó correctamente";
            return RedirectToAction("Index");
        }


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

