using API_REST.DataBase;
using API_REST.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticulosServices _ArticuloServices;

        public ArticulosController(ArticulosServices ArticuloServices)
        {
            _ArticuloServices = ArticuloServices;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult> Get()
        {

            return Ok(await _ArticuloServices.Get());
        }


        [HttpGet]
        [Route("GetId")]

        public async Task<ActionResult> GetOne(int id)
        {
            if(await _ArticuloServices.GetId(id) != null)
            {
                return Ok(await _ArticuloServices.GetId(id));
            }

            return NotFound("El articulo no se ha encontrado");

        }


        [HttpPost]
        [Route("Post")]

        public async Task<ActionResult> Post(Articulo articulo)
        {
            
            if(articulo.Codigo != null)
            {
                if(await _ArticuloServices.Post(articulo) != null)
                {
                    return Ok("Se ha añadido exitosamente");
                }
                
            }
            return Ok("El articulo recibido estaba vacio");
        }

        [HttpPut]
        [Route("Put")]

        public async Task<ActionResult> Put(Articulo articulo)
        {


           if(articulo.Id != 0 && articulo.Codigo != null && articulo.Nombre != null && articulo.Descripcion != null && articulo.IdMarca != 0 
                && articulo.IdCategoria != 0 && articulo.Precio != 0 && articulo.ImagenUrl != null)
            {
                if(await _ArticuloServices.Put(articulo) != null)
                {
                    return Ok("Se ha modificado exitosamente");
                }
                else
                {
                    return Ok("El articulo a modificar no se ha encontrado");
                }
                
            }
            return Ok("Debe completar los datos antes de enviar");
         }

        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult> Delete(int Id)
        {


            if(await _ArticuloServices.Delete(Id) == 1)
            {
                return Ok("El articulo se ha eliminado");
            }
            else
            {
                return NotFound("El articulo no se ha encontrado");
            }
        }
    }
}
