using ApplicationCore.DTOs;
using ApplicationCore.DTOs.Logs;
using ApplicationCore.DTOs.Personaje;
using ApplicationCore.Wrappers;

namespace ApplicationCore.Interfaces
{
    public interface IDashboardService
    {
        Task<Response<object>> GetData();
        Task<Response<int>> Create( PersonajeDto request);

        Task<Response<int>> Update( PersonajeDto request, int personajeId);

        Task<Response<int>> Delete(int personajeId);

        Task<Response<string>> GetIp();

        Task<Response<int>> CreateLogs(LogsDto request);


    }
}
