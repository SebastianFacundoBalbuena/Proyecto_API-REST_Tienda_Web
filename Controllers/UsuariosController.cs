using API_REST.DataBase;
using API_REST.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosServices _UsuarioServices;
        public UsuariosController(UsuariosServices UsuarioServices) { 
        
         _UsuarioServices = UsuarioServices;
        }

        [HttpGet]
        [Route("GetIdUsuarios")]

        public async Task<ActionResult> GetIdUsuarios(int id)
        {

            if(id != 0)
            {
                if(await _UsuarioServices.GetId(id) != null)
                {
                    return Ok(await _UsuarioServices.GetId(id));
                }
                else
                {
                    return Ok("El usuario no se encontro");
                }
            }

            return Ok("Debe ingresar el id del usuario");
        }


        [HttpPost]
        [Route("Post")]

        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
           

            if(usuario.Email != null && usuario.Contraseña != null && usuario.Nombre != null && usuario.Apellido != null)
            {

                await _UsuarioServices.Post(usuario);
                return Ok("Se ha creado un nuevo usuario");
            }

            return Ok("El usuario ingresado no contiene datos");
        }


        [HttpPut]
        [Route("Put")]

        public async Task<ActionResult<Usuario>> PutUsuario(Usuario usuario)
        {
            if(usuario.Id != 0)
            {
                if(usuario.Contraseña != null  && usuario.Nombre != null && usuario.Apellido != null)
                {
                    if (await _UsuarioServices.Put(usuario) != null)
                    {
                        return Ok("Se ha modificado exitosamente");
                    }
                }
                else
                {
                    return Ok("Algunos campos estan vacios");
                }




            }
            else
            {
                return Ok("Debe enviar el id del usuario");
            }




            return Ok("Usuario no encontrado");
        }
    }
}
