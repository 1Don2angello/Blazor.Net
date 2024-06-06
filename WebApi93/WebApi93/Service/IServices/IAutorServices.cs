using Domain.Entities;
namespace WebApi93.Service.IServices
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> Crear(Autor i);
    }
}
