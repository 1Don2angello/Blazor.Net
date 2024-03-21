﻿using ApplicationCore.DTOs;
using ApplicationCore.DTOs.Usuario;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        /// validaciones 
        private void ValidateUsuarioCompletoDTO(UsuarioCompletoDTO usuario)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                errors.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                errors.Add("El apellido es obligatorio.");
            if (usuario.Edad <= 0)
                errors.Add("La edad debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@"))
                errors.Add("Debe proporcionar un correo electrónico válido.");
            if (string.IsNullOrWhiteSpace(usuario.Telefono))
                errors.Add("El teléfono es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Direccion))
                errors.Add("La dirección es obligatoria.");
            if (string.IsNullOrWhiteSpace(usuario.Ciudad))
                errors.Add("La ciudad es obligatoria.");
            if (string.IsNullOrWhiteSpace(usuario.Pais))
                errors.Add("El país es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.CodigoPostal))
                errors.Add("El código postal es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Genero))
                errors.Add("El género es obligatorio.");
            // Agregar más validaciones conforme a las reglas de negocio
            if (errors.Any())
                throw new ArgumentException(string.Join(" ", errors));
        }


        //get data 
        public async Task<Response<object>> GetData()
        {
            var list = await _dbContext.Usuarios.ToListAsync();
            return new Response<object>(list);
        }



        /// este es create con try cachar
        public async Task<Response<int>> Create(UsuarioCompletoDTO request)
        {
            try
            {
                // Validar el DTO de entrada
                ValidateUsuarioCompletoDTO(request);
                var usuario = _mapper.Map<UsuarioCompleto>(request);
                await _dbContext.Usuarios.AddAsync(usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(usuario.Id, "Usuario creado exitosamente.");
            }
            catch (Exception ex)
            {
                // Aquí registras el error antes de lanzar la excepción para que sea capturado en un nivel superior,
                // como un middleware de manejo de errores que puede registrar el error y responder adecuadamente.
                await LogError("Create", JsonConvert.SerializeObject(request), ex.Message);
                return new Response<int>(0, ex.Message);
            }
        }

        ///// este es update 
        public async Task<Response<int>> Update(UsuarioCompletoDTO request)
        {
            try
            {
                ValidateUsuarioCompletoDTO(request);
                var usuario = await _dbContext.Usuarios.FindAsync(request.Id);
                if (usuario == null)
                {
                    throw new KeyNotFoundException($"Usuario con ID {request.Id} no encontrado.");
                }
                _mapper.Map(request, usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(usuario.Id, "Usuario actualizado exitosamente");
            }
            catch (Exception ex)
            {
                await LogError("Update", JsonConvert.SerializeObject(request), ex.Message);
                return new Response<int>(0, ex.Message);
            }
        }
        /// este es delete 
        //public async Task<Response<int>> Delete(int id)
        //{
        //    var usuario = await _dbContext.Usuarios.FindAsync(id);
        //    if (usuario == null)
        //    {
        //        return new Response<int>(0, "Usuario no encontrado");
        //    }
        //    _dbContext.Usuarios.Remove(usuario);
        //    await _dbContext.SaveChangesAsync();
        //    return new Response<int>(id, "Usuario eliminado exitosamente");
        //}
        public async Task<Response<int>> Delete(int id)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    throw new KeyNotFoundException($"Usuario con ID {id} no encontrado.");
                }
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(id, "Usuario eliminado exitosamente");
            }
            catch (Exception ex)
            {
                await LogError("Delete", id.ToString(), ex.Message);
                return new Response<int>(0, ex.Message); 
            }
        }


        ///este es de los logs
        public Task<Response<int>> GetLogsCreate(LogsDto request)
        {
            throw new NotImplementedException();
        }
        ////
        ///este funciona y usa log error
        private async Task LogError(string funcion, string datos, string respuesta, string ipAdress = null)
        {
            var log = new Logs
            {
                IpAdress = ipAdress ?? GetClientIp(),
                Funcion = funcion,
                Datos = datos,
                Respuesta = respuesta
            };

            _dbContext.logs.Add(log);
            await _dbContext.SaveChangesAsync();
        }

        private string GetClientIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            return ip?.ToString() ?? "IP desconocida";
        }
        public async Task<Response<string>> GetIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            return new Response<string>(ip?.ToString() ?? "IP no encontrada");
        }
    }
}
