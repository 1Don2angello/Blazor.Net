using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Wrappers;
using ApplicationCore.DTOs.persona;
using ApplicationCore.DTOs.formulario;
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
        public async Task<ActionResult<Response<int>>> create([FromBody] PersonaDto request)
        {
            var result = await _service.Create(request);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<Response<int>>> Update(int id, [FromBody] PersonaDto request)
        {
            var result = await _service.Update(id, request);
            return Ok(result);
        }


        [HttpGet("GetIp")]
        public async Task <IActionResult> GetIpAdress()
        {
            var result = await _service.GetIp();
            return Ok(result);
        }
        [HttpGet("GetFormIp")]
        public async Task<IActionResult> GetFormIp()
        {
            var resultado = await _service.GetFormIp();
            return Ok(resultado);
        }

    }
}
