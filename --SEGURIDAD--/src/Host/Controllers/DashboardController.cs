using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Wrappers;
using Domain.Entities;
using ApplicationCore.DTOs.Personaje;
using ApplicationCore.DTOs.Logs;
using Infraestructure.Services;

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

        [Route("getData")]

        [HttpGet()]
        //[Authorize]
        public async Task<IActionResult> GetPersonajes()
        {
            var result = await _service.GetData();
            return Ok(result);
        }

        [HttpPost("Create")]

        public async Task<ActionResult<Response<int>>> Create([FromBody] PersonajeDto request)
        {
            var result = await _service.Create(request);
            return Ok(result);
        }

        [HttpPut("{personajeId}")]
        public async Task<ActionResult<Response<int>>> Update(int personajeId, [FromBody] PersonajeDto request)
        {
            var result = await _service.Update(request, personajeId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            return Ok(result);
        }

        [HttpGet("GetIp")]
        public async Task<IActionResult> GetIp()
        {
            var result = await _service.GetIp();
            return Ok(result);
        }

        [HttpPost("CreateLogs")]

        public async Task<ActionResult<Response<int>>> Create([FromBody] LogsDto request)
        {
            var result = await _service.CreateLogs(request);
            return Ok(result);
        }

    }
}
