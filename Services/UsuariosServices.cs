using API_REST.DataBase;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Services
{
    public class UsuariosServices
    {
        private readonly CatalogoDbContext _Context;

        public UsuariosServices(CatalogoDbContext Context)
        {

            _Context = Context;

        }

        public async Task<Usuario> GetId(int id)
        {
            Usuario? usuario = await _Context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);


            return usuario;
        }

        public async Task<Usuario> Post(Usuario usuario)
        {
            Usuario NewUsuario = new Usuario();

            NewUsuario.Email = usuario.Email;
            NewUsuario.Contraseña = usuario.Contraseña;
            NewUsuario.TipoDeUsuario = 0;
            NewUsuario.FechaDeNacimiento = usuario.FechaDeNacimiento;
            NewUsuario.Nombre = usuario.Nombre;
            NewUsuario.Apellido = usuario.Apellido;
            NewUsuario.ImagenPerfil = usuario.ImagenPerfil;

            await _Context.Usuarios.AddAsync(NewUsuario);
            _Context.SaveChanges();

            return NewUsuario;
        }

        public async Task<Usuario> Put(Usuario usuario)
        {
            Usuario? UpdateUsuario = await _Context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);

            if (UpdateUsuario != null)
            {
                UpdateUsuario.Contraseña = usuario.Contraseña;
                UpdateUsuario.FechaDeNacimiento = usuario.FechaDeNacimiento;
                UpdateUsuario.Nombre = usuario.Nombre;
                UpdateUsuario.Apellido = usuario.Apellido;
                UpdateUsuario.ImagenPerfil = usuario.ImagenPerfil;

                if (usuario.TipoDeUsuario == 0)
                {
                    UpdateUsuario.TipoDeUsuario = 0;
                }
                else
                {
                    UpdateUsuario.TipoDeUsuario = 1;
                }

                _Context.Usuarios.Update(UpdateUsuario);
                _Context.SaveChanges();

                return UpdateUsuario;

            }

            return UpdateUsuario;

        }
    }
}
