using ApplicationCore.DTOs;
using ApplicationCore.DTOs.Usuario;
using ApplicationCore.Wrappers;

namespace ApplicationCore.Interfaces
{
    public interface IDashboardService
    {
        Task<Response<object>> GetData();

        Task<Response<int>> Create(UsuarioCompletoDTO request);

        Task<Response<int>> Update(UsuarioCompletoDTO request);

        Task<Response<string>> GetIp();

        Task<Response<int>> GetLogsCreate(LogsDto request);
        Task<Response<int>> Delete(int id);
    }

}