using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO.Pipelines;

namespace TecnoShop.Models
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly TecnoShopDbContext _tecnoShopDbContext;
        public CategoriaRepositorio(TecnoShopDbContext tecnoShopDbContext)
        {
            _tecnoShopDbContext = tecnoShopDbContext;
        }


        //public IEnumerable<Categoria> TodasLasCategorias()
        //{
        //    List<Categoria> categorias = _tecnoShopDbContext.Categorias.ToList();
        //    return categorias;
        //}


        //public IEnumerable<Categoria> TodasLasCategorias
        //{
        //    get { return _tecnoShopDbContext.Categorias; }
        //}


        public IEnumerable<Categoria> TodasLasCategorias => _tecnoShopDbContext.Categorias.OrderBy(x => x.CategoriaId);


        public Categoria? ObtenerCategoria(int categoriaId)
        {
            Categoria? categoria = _tecnoShopDbContext.Categorias.Where(c => c.CategoriaId == categoriaId).FirstOrDefault();
            return categoria;
        }


        public void CrearCategoria(Categoria categoria)
        {
            categoria.Productos = new List<Producto>();
            _tecnoShopDbContext.Categorias.Add(categoria);
            _tecnoShopDbContext.SaveChanges();

        }
        public void EditarCategoria(Categoria categoria)
        {
            _tecnoShopDbContext.Categorias.Update(categoria);
            _tecnoShopDbContext.SaveChanges();
        }

        public void EliminarCategoria(Categoria categoria)
        {
            _tecnoShopDbContext.Categorias.Remove(categoria);
            _tecnoShopDbContext.SaveChanges();
        }

        public List<SelectListItem> CategoriaItems()
        {
            var listaCategorias = new List<SelectListItem>();
            List<Categoria> categorias = _tecnoShopDbContext.Categorias.ToList();
            listaCategorias = categorias.Select(cat => new SelectListItem()
            {
                Value = cat.CategoriaId.ToString(),
                Text = cat.Nombre
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "-- Selecciona una Categoría --"
            };
            listaCategorias.Insert(0, defItem);
            return listaCategorias;
        }
    }
}
