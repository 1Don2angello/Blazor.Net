//Estado: pendiente
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.Usuario;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Newtonsoft.Json;

namespace Infraestructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DashboardService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Response<object>> GetData()
        {
            try
            {
                var list = await _dbContext.Usuarios.ToListAsync();
                return new Response<object>(list, true, "Datos recuperados con éxito.");
            }
            catch (Exception ex)
            {
                await LogError(null, ex, "GetData");
                return new Response<object>(null, false, "Error al recuperar datos.");
            }
        }

        public async Task<Response<int>> Create(UsuarioCompletoDTO request)
        {
            try
            {
                var usuario = _mapper.Map<UsuarioCompleto>(request);
                await _dbContext.Usuarios.AddAsync(usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(usuario.Id, true, "Usuario creado exitosamente.");
            }
            catch (Exception ex)
            {
                await LogError(request, ex, "Create");
                return new Response<int>(0, false, "Error al crear el usuario.");
            }
        }

        public async Task<Response<int>> Update(UsuarioCompletoDTO request)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.FindAsync(request.Id);
                if (usuario == null)
                {
                    return new Response<int>(0, false, "Usuario no encontrado");
                }

                _mapper.Map(request, usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(usuario.Id, true, "Usuario actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                await LogError(request, ex, "Update");
                return new Response<int>(0, false, "Error al actualizar el usuario.");
            }
        }

        public async Task<Response<int>> Delete(int id)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<int>(0, false, "Usuario no encontrado");
                }

                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(id, true, "Usuario eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                await LogError(id, ex, "Delete");
                return new Response<int>(0, false, "Error al eliminar el usuario.");
            }
        }

        public async Task<Response<string>> GetIp()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                var ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
                return new Response<string>(ip?.ToString() ?? "IP no encontrada", true, "IP obtenida con éxito.");
            }
            catch (Exception ex)
            {
                await LogError(null, ex, "GetIp");
                return new Response<string>("", false, "Error al obtener la IP.");
            }
        }

        public Task<Response<int>> GetLogsCreate(LogsDto request)
        {
            // Implementación del registro de logs
            throw new NotImplementedException();
        }

        private async Task LogError(object request, Exception exception, string action)
        {
            var logEntry = new LogsDto
            {
                IpAdress = GetClientIp(),
                Funcion = action,
                Respuesta = exception.Message,
                Datos = request != null ? JsonConvert.SerializeObject(request) : "N/A"
            };

            var logEntity = _mapper.Map<Log>(logEntry);
            _dbContext.Logs.Add(logEntity);
            await _dbContext.SaveChangesAsync();
        }

        private string GetClientIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            return ip?.ToString() ?? "IP desconocida";
        }
    }
}
