using API_REST.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly CatalogoDbContext _Context;

        public ArticulosController(CatalogoDbContext Context)
        {
            _Context = Context;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult> Get()
        {
            var listaCatalogo = await _Context.Articulos.ToListAsync();
            return Ok(listaCatalogo);
        }


        [HttpGet]
        [Route("GetId")]

        public async Task<ActionResult> GetOne(int id)
        {
            Articulo? Obtener = await _Context.Articulos.FirstOrDefaultAsync(a => a.Id == id);

            if (Obtener != null)
            {
                return Ok(Obtener);
            }

            return NotFound("Articulo no encontrado");

        }


        [HttpPost]
        [Route("Post")]

        public async Task<ActionResult> Post(Articulo articulo)
        {
            Articulo NewArticulo = new Articulo();

            NewArticulo.Nombre = articulo.Nombre;
            NewArticulo.Codigo = articulo.Codigo;
            NewArticulo.Descripcion = articulo.Descripcion;
            NewArticulo.IdMarca = articulo.IdMarca;
            NewArticulo.IdCategoria = articulo.IdCategoria;
            NewArticulo.ImagenUrl = articulo.ImagenUrl;
            NewArticulo.Precio = articulo.Precio;

            if (NewArticulo != null)
            {
                await _Context.Articulos.AddAsync(NewArticulo);
                _Context.SaveChanges();
                return Ok("Guardado Exitoso!");
            }

            return Ok("El articulo recibido estaba vacio");
        }

        [HttpPut]
        [Route("Put")]

        public async Task<ActionResult> Put(Articulo articulo)
        {
            Articulo? UpdateArticulo = await _Context.Articulos.FirstOrDefaultAsync(a => a.Id == articulo.Id);

            if(UpdateArticulo != null)
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

                return Ok("Actualizado exitosamente!");
            }

            return Ok("No se ha encontrado el articulo a actualizar");

         }

        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult> Delete(int Id)
        {
            Articulo? deleteArticulo = await _Context.Articulos.FirstOrDefaultAsync(a => a.Id == Id);

            if(deleteArticulo != null)
            {
                 _Context.Articulos.Remove(deleteArticulo);
                _Context.SaveChanges();

                return Ok("Articulo eliminado");
            }

            return Ok("No se ha encontrado el articulo a eliminar");
        }
    }
}
