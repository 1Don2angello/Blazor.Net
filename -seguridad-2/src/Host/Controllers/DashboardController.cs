using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Wrappers;
using Domain.Entities;
using ApplicationCore.DTOs.Usuario;
using Org.BouncyCastle.Asn1.Ocsp;
using ApplicationCore.DTOs;

namespace Host.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        public DashboardController(IDashboardService service)
        {
            _service = service;
        }


        [HttpGet("getData")]
        public async Task<IActionResult> GetUsuarios()
        {
            var result = await _service.GetData();
            return Ok(result);
        }


        [HttpPost("Create")]

        public async Task<ActionResult<Response<int>>>Create([FromBody] UsuarioCompletoDTO request)
        {
            var result = await _service.Create(request);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UsuarioCompletoDTO request)
        {
            var result = await _service.Update(request);
            return Ok(result);
        }


        [HttpGet("GetIp")]

        public async Task<IActionResult> GetIp()
        {
            var result = await _service.GetIp();
            return Ok(result);
        }

        [HttpPost("createLogs")]
        public async Task<ActionResult<Response<int>>> CreateLogs([FromBody] LogsDto request)
        {
            var result = await _service.GetLogsCreate(request);
            return Ok(result);
        }
    }
}
