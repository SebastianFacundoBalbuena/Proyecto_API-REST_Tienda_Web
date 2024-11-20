using API_REST.DataBase;
using API_REST.Services;
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
        private readonly RegistrosServices _RegistroServices;
        public RegistrosController(RegistrosServices RegistroServices) {

            _RegistroServices = RegistroServices;
        }


        [HttpGet]
        [Route("GetRegistros")]
        public async Task<ActionResult<List<Registro>>> Get()
        {
            return Ok(await _RegistroServices.Get());
            
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<Registro>> Post(Registro registro)
        {

            if(await _RegistroServices.Post(registro) != null)
            {
                return Ok("Se ha almacenado correctamente");
            }

            return Ok("Algunos campos son requeridos");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if(await _RegistroServices.Delete(id) != 0)
            {
                return Ok("Eliminado correctamente");
            }

            return Ok("No se ha encontrado el registro");
        }
    }
}
