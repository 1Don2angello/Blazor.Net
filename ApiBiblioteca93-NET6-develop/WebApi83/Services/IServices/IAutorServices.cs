using Domain.Entities;

namespace WebApi83.Services.IServices
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> Crear(Autor i);

    }
}
