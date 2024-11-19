using API_REST.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly CatalogoDbContext _Context;
        public MarcasController(CatalogoDbContext Context) { 
        
            _Context = Context;
        
        }

        [HttpGet]
        [Route("GetMarcas")]

        public async Task<ActionResult<List<Marca>>> GetMarcas()
        {
            List<Marca> listaMarcas = await _Context.Marcas.ToListAsync();
            
            if(listaMarcas.Count != 0)
            {
                return Ok(listaMarcas);
            }

            return Ok("Hubo un error al solicitar las marcas");
            
        }

    }
}
