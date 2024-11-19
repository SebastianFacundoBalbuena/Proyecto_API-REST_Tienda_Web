using API_REST.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly CatalogoDbContext _Context;
        public UsuariosController(CatalogoDbContext Context) { 
        
         _Context = Context;
        }

        [HttpGet]
        [Route("GetIdUsuarios")]

        public async Task<ActionResult> GetIdUsuarios(int id)
        {
            Usuario? usuario = await _Context.Usuarios.FirstOrDefaultAsync(u=>u.Id == id);

            if(usuario != null)
            {
                return Ok(usuario);
            }

            return Ok("Usuario no encontrado");
        }


        [HttpPost]
        [Route("Post")]

        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            Usuario NewUsuario = new Usuario();

            if(usuario != null)
            {
                NewUsuario.Email = usuario.Email;
                NewUsuario.Contraseña = usuario.Contraseña;
                NewUsuario.TipoDeUsuario = 0;
                NewUsuario.FechaDeNacimiento = usuario.FechaDeNacimiento;
                NewUsuario.Nombre = usuario.Nombre;
                NewUsuario.Apellido = usuario.Apellido;
                NewUsuario.ImagenPerfil = usuario.ImagenPerfil;

                await _Context.Usuarios.AddAsync(NewUsuario);
                _Context.SaveChanges();

                return Ok("Usuario añadido exitosamente!");
            }

            return Ok("El usuario ingresado no contiene datos");
        }


        [HttpPut]
        [Route("Put")]

        public async Task<ActionResult<Usuario>> PutUsuario(Usuario usuario)
        {
            Usuario? UpdateUsuario = await _Context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);

            if(UpdateUsuario != null)
            {
                UpdateUsuario.Contraseña = usuario.Contraseña;
                UpdateUsuario.FechaDeNacimiento = usuario.FechaDeNacimiento;
                UpdateUsuario.Nombre = usuario.Nombre;
                UpdateUsuario.Apellido = usuario.Apellido;
                UpdateUsuario.ImagenPerfil = usuario.ImagenPerfil;

                _Context.Usuarios.Update(UpdateUsuario);
                _Context.SaveChanges();

                return Ok("Usuario actualizado");
            }

            return Ok("Usuario no encontrado");
        }
    }
}
