using ApplicationCore.DTOs;
using ApplicationCore.DTOs.Usuario;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

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
            var list = await _dbContext.Usuarios.ToListAsync();
            return new Response<object>(list);
        }

        public async Task<Response<int>> Create(UsuarioCompletoDTO request)
        {
            var usuario = _mapper.Map<UsuarioCompleto>(request);
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return new Response<int>(usuario.Id, "Usuario creado exitosamente");
        }

        public async Task<Response<int>> Update(UsuarioCompletoDTO request)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(request.Id);
            if (usuario == null)
            {
                return new Response<int>(0, "Usuario no encontrado");
            }

            _mapper.Map(request, usuario);
            await _dbContext.SaveChangesAsync();

            return new Response<int>(usuario.Id, "Usuario actualizado exitosamente");
        }

        public async Task<Response<int>> Delete(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return new Response<int>(0, "Usuario no encontrado");
            }

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();

            return new Response<int>(id, "Usuario eliminado exitosamente");
        }

        public async Task<Response<string>> GetIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            return new Response<string>(ip?.ToString() ?? "IP no encontrada");
        }

        public Task<Response<int>> GetLogsCreate(LogsDto request)
        {
            throw new NotImplementedException();
        }
    }
}
