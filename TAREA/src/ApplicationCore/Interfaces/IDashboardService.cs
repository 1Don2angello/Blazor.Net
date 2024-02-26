using ApplicationCore.DTOs;
using ApplicationCore.DTOs.persona;
using ApplicationCore.Wrappers;

namespace ApplicationCore.Interfaces
{
    public interface IDashboardService
    {
        Task<Response<object>> GetData();
        Task<Response<int>> Create(PersonaDto request);
        Task<Response<int>> Update(int id, PersonaDto request);
        Task<Response<string>> GetIp();
    }
}
