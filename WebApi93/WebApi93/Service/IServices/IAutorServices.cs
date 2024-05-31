using Domain.Entities;
namespace WebApi93.Service.IServices
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
    }
}
