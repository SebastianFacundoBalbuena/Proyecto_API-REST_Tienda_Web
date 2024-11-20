using API_REST.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace API_REST.Services
{
    public class RegistrosServices
    {
        private readonly CatalogoDbContext _Context;

        public RegistrosServices(CatalogoDbContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Registro>> Get()
        {
            List<Registro> lista = await _Context.Registros.ToListAsync();

            return lista;
        }

        public async Task<Registro> Post(Registro registro)
        {
            Registro NewRegistro = null;

            if (registro.Producto != null && registro.Codigo != null && registro.Cantidad != 0 && registro.FechaDeVenta != null && registro.Precio != null)
            {
                NewRegistro = new Registro();

                NewRegistro.Producto = registro.Producto;
                NewRegistro.Cantidad = registro.Cantidad;
                NewRegistro.FechaDeVenta = registro.FechaDeVenta;
                NewRegistro.Precio = registro.Precio;
                NewRegistro.Codigo = registro.Codigo;

                await _Context.Registros.AddAsync(NewRegistro);
                _Context.SaveChanges();

                return NewRegistro;
            }
            return NewRegistro;
        }

        public async Task<int>Delete(int id)
        {
            Registro? registro = await _Context.Registros.FirstOrDefaultAsync(r => r.Id == id);

            if (registro != null)
            {
                _Context.Registros.Remove(registro);
                _Context.SaveChanges();

                return 1;
               
            }

            return 0;
        }
    }
}
