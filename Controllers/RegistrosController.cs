using API_REST.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly CatalogoDbContext _Context;
        public RegistrosController(CatalogoDbContext Context) {

            _Context = Context;
        }


        [HttpGet]
        [Route("GetRegistros")]
        public async Task<ActionResult<List<Registro>>> Get()
        {
            List<Registro> lista = await _Context.Registros.ToListAsync();

            if(lista.Count != 0)
            {
                return Ok(lista);
            }

            return Ok("No se encontraron registros");
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<Registro>> Post(Registro registro)
        {
            Registro NewRegistro = new Registro();

            if(registro != null)
            {
                NewRegistro.Producto = registro.Producto;
                NewRegistro.Cantidad = registro.Cantidad;
                NewRegistro.FechaDeVenta = registro.FechaDeVenta;
                NewRegistro.Precio = registro.Precio;
                NewRegistro.Codigo = registro.Codigo;

                await _Context.Registros.AddAsync(NewRegistro);
                _Context.SaveChanges();

                return Ok("Registro agregado exitosamente!");
            }

            return Ok("Se ha enviado un registro sin datos");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            Registro? registro = await _Context.Registros.FirstOrDefaultAsync(r => r.Id == id);

            if(registro != null)
            {
                _Context.Registros.Remove(registro);
                _Context.SaveChanges();

                return Ok("Registro eliminado");
            }

            return Ok("No se ha encontrado el registro a eliminar");
        }
    }
}
