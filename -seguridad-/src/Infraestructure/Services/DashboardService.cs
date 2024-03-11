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
using ApplicationCore.DTOs.Usuario;
using System.Text.Json;
using ApplicationCore.Mappers;

namespace Infraestructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public DashboardService(ApplicationDbContext dbContext, ICurrentUserService currentUserService,IMapper mapper)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<Response<Object>> GetData()
        {
            object list = new object();
            list = await _dbContext.Usuarios.ToListAsync();
            return new Response<Object>(list);
        }


        public async Task<Response<int>> Create(UsuarioDTO request)
        {
            var  newUsuario = _mapper.Map<Domain.Entities.Usuarios>(request);
            await _dbContext.Usuarios.AddAsync(newUsuario);
            await _dbContext.SaveChangesAsync();
            var respuestaUno = new Response<int>(1, "Registro craedo");

            var log = new LogsDto();
            var usuario = JsonSerializer.Serialize(request);

            log.Datos = usuario;
            log.Funcion = "Usuario";
            log.Respuesta = "eeee";
            await GetLogsCreate(log);
            return respuestaUno;
        }

        public async Task<Response<int>> Update(UsuarioDTO request)
        {
            // Buscar el usuario que se desea actualizar en la base de datos
            var existingUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == request.Id);

            // Verificar si el usuario existe
            if (existingUsuario == null)
            {
                return new Response<int>(0); // Si el usuario no existe, devuelve un código de respuesta indicando que no se pudo actualizar
            }

            // Actualizar los campos del usuario existente con los valores proporcionados en la solicitud
            existingUsuario.Nombre = request.Nombre;
            existingUsuario.Apellido = request.Apellido;
            // Actualiza cualquier otro campo necesario

            // Guardar los cambios en la base de datos
            await _dbContext.SaveChangesAsync();

            return new Response<int>(1); // Devuelve un código de respuesta indicando que la actualización fue exitosa
        }


        public async Task<Response<string>> GetIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            var Ip = iPAddress?.ToString() ?? "'No se detecto IP :|'";
            return new Response<string> (Ip);
        }

        public Task<Response<int>> GetClientUserAsync(UsuarioDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> GetLogsCreate(LogsDto request)
        {
            var ipResponse = await GetIp(); // Obtener la IP de forma asíncrona
            var ip = ipResponse.Message; // Obtener la IP del resultado

            var c = new LogsDto();
            c.IpAdress = ip; // Asignar la IP obtenida al campo IpCliente
            c.Funcion = request.Funcion;
            c.Respuesta = request.Respuesta;
            c.Datos = request.Datos;

            var fu = _mapper.Map<Domain.Entities.Logs>(c);
            await _dbContext.logs.AddAsync(fu);
            await _dbContext.SaveChangesAsync();

            return new Response<int>(fu.Id, "Registro creado"); // Devolver el valor de PkIp como respuesta del método
        }
    }
}
