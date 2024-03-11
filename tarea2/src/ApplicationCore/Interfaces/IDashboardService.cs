using ApplicationCore.DTOs;

using ApplicationCore.Wrappers;

namespace ApplicationCore.Interfaces
{
    public interface IDashboardService
    {
        Task<Response<object>> GetData();
        
        Task<Response<int>> Create(UsuarioDto request);

        Task<Response<int>> GetClientUserAsync(UsuarioDto request);

        Task<Response<string>> GetClientIpAddress();

        Task<Response<int>> GetLogsCreate( LogsDto request);
        
    }
}
