using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Dapper;
using Infraestructure.Persistence;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.DTOs.persona;
using ApplicationCore.DTOs.formulario;
using System.Net.Sockets;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;


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
            list = await _dbContext.Usuers.ToListAsync();
            return new Response<object>(list);
        }
        public async Task<Response<int>> Create(PersonaDto request)
        {
            var newPersona = _mapper.Map<Domain.Entities.Usuers>(request);
            await _dbContext.Usuers.AddAsync(newPersona);
            await _dbContext.SaveChangesAsync();
            return new Response<int>(1);

        }
        public async Task<Response<int>> Update(int id, PersonaDto request)
        {
            var persona = await _dbContext.Usuers.FindAsync(id);
            if (persona == null)
            {
                return new Response<int>(0); // Usuario no encontrado, se puede devolver un código de error o lanzar una excepción
            }

            _mapper.Map(request, persona); // Mapear los datos del DTO al objeto de la base de datos

            _dbContext.Usuers.Update(persona);
            await _dbContext.SaveChangesAsync();

            return new Response<int>(1); // Operación exitosa
        }
        public async Task<Response<string>>GetIp() 
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            var ipAdressString = iPAddress?.ToString() ?? "No se pudo determinar la direccion ip";
            return new Response<string> (ipAdressString );
        }

        public async Task<Response<int>> GetFormIp(formDTOs request)
        {
            var newPersona = _mapper.Map<Domain.Entities.formulario_ip>(request);
            await _dbContext.formulario-ip.AddAsync(newPersona);
            await _dbContext.SaveChangesAsync();
            return new Response<int>(1);
            // Implementation logic for getting the form IP goes here
            // You can use the `HttpContext` to get the IP address of the current request
            //var ipAddress2 = HttpContext.Connection.RemoteIpAddress.ToString();
            //return new Response<string>(ipAddress2);
        }
    }
}