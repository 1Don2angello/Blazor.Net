using Domain.Entities;

namespace WebApi83.Services.IServices
{
    public interface IUsuarioServices
    {

        public Task<Response<List<Usuario>>> ObtenerUsuarios();
        public Task<Response<Usuario>> Crear(UsuarioResponse request);
        public Task<Response<Usuario>> ById(int id);

    }
}
