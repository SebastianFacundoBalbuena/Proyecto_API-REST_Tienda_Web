using API_REST.DataBase;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Services
{
    public class ArticulosServices
    {
        private readonly CatalogoDbContext _Context;

        public ArticulosServices(CatalogoDbContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Articulo>> Get()
        {
            var listaCatalogo = await _Context.Articulos.ToListAsync();
            return listaCatalogo;
        }

        public async Task<Articulo> GetId(int id)
        {
            Articulo? Obtener = await _Context.Articulos.FirstOrDefaultAsync(a => a.Id == id);


            return Obtener;
        }

        public async Task<Articulo> Post(Articulo articulo)
        {
            Articulo NewArticulo = new Articulo();

            NewArticulo.Nombre = articulo.Nombre;
            NewArticulo.Codigo = articulo.Codigo;
            NewArticulo.Descripcion = articulo.Descripcion;
            NewArticulo.IdMarca = articulo.IdMarca;
            NewArticulo.IdCategoria = articulo.IdCategoria;
            NewArticulo.ImagenUrl = articulo.ImagenUrl;
            NewArticulo.Precio = articulo.Precio;


                await _Context.AddAsync(NewArticulo);
                _Context.SaveChanges();

                return NewArticulo;
            

            
        }

        public async Task<Articulo> Put(Articulo articulo)
        {
            Articulo? UpdateArticulo = await _Context.Articulos.FirstOrDefaultAsync(a => a.Id == articulo.Id);

            if (UpdateArticulo != null)
            {

                UpdateArticulo.Codigo = articulo.Codigo;
                UpdateArticulo.Nombre = articulo.Nombre;
                UpdateArticulo.Descripcion = articulo.Descripcion;
                UpdateArticulo.IdMarca = articulo.IdMarca;
                UpdateArticulo.IdCategoria = articulo.IdCategoria;
                UpdateArticulo.ImagenUrl = articulo.ImagenUrl;
                UpdateArticulo.Precio = articulo.Precio;

                _Context.Articulos.Update(UpdateArticulo);
                _Context.SaveChanges();

                
            }

            return UpdateArticulo;
        }

        public async Task<int>Delete(int id)
        {
            Articulo? deleteArticulo = await _Context.Articulos.FirstOrDefaultAsync(a => a.Id == id);

            if (deleteArticulo != null)
            {
                _Context.Articulos.Remove(deleteArticulo);
                _Context.SaveChanges();

                return 1;
            }

            return 0;
        }
    }
}
