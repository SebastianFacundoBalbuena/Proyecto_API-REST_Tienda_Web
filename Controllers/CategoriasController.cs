using API_REST.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CatalogoDbContext _Context;

        public CategoriasController(CatalogoDbContext Context)
        {
            _Context = Context;
        }

        [HttpGet]
        [Route("GetCategorias")]

        public async Task<ActionResult<List<Categoria>>> GetCategorias()
        {
            List<Categoria> listaCategoria = await _Context.Categorias.ToListAsync();

            if(listaCategoria.Count != 0)
            {
                return Ok(listaCategoria);
            }

            return Ok("Hubo un error al solicitar las categorias");
        }
    }
}
