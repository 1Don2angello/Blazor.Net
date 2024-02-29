using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Dapper;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Net;
using ApplicationCore.Commads;
using AutoMapper;

namespace Infraestructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public DashboardService(ApplicationDbContext dbContext, ICurrentUserService currentUserService, IMapper mapper)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;   
        }

        public async Task<Response<object>> GetData()
        {
            object list = new object();
            list = await _dbContext.user.ToListAsync();
            return new Response<object>(list);
        }

        public async Task<Response<string>> GetClientIpAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            var ipAdressString = iPAddress?.ToString() ?? "No se pudo determinar la direccion IP del servidor";
            return new Response<string>(ipAdressString);
        }

        public Task<Response<int>> GetClientUserAsync(UsuarioDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> GetLogsCreate(LogsDto request)
        {
            
            var ip = GetClientIpAddress().Result.Message;
            var c = new LogsDto();
            c.IpAddress = ip;
            c.NomFuncion = request.NomFuncion;
            c.Fecha = request.Fecha;
            c.Datos = request.Datos;
            c.StatusLog = request.StatusLog;


            var ca = _mapper.Map<Domain.Entities.Logs>(c);
            await _dbContext.logs.AddAsync(ca);
            await _dbContext.SaveChangesAsync();
            return new Response<int>(ca.Id, "Registro creado");
        }
    }
}