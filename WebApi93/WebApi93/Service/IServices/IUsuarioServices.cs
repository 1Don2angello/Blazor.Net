using Domain.Entities;
namespace WebApi93.Service.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> ObtenerUsuarios();
        public Task<Response<Usuario>> Crear(UsuarioResponse request);
        public Task<Response<Usuario>> ById(int id);

        public Task<Response<Usuario>> Editar(int id, UsuarioResponse request);
        public Task<Response<bool>> Eliminar(int id);

    }

}
