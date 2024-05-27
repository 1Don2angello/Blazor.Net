using Domain.Entities;
namespace WebApi93.Service.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> ObtenerUsuarios();
    }
}
