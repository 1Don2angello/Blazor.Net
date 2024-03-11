using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using ApplicationCore.DTOs;
using Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

using ApplicationCore.Commads;


namespace Host.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        private readonly IMediator _mediator;
        public DashboardController(IDashboardService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GastoPendienteArea()
        {
            var origin = Request.Headers["origin"];
            return Ok("test");
        }


        [Route("getData")]
        [HttpGet()]
        public async Task<IActionResult> GetUsuarios()
        {
            var result = await _service.GetData();
            return Ok(result);
        }

        [HttpPost("createUser")]
        public async Task<ActionResult<Response<int>>> Create(CreateUserCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Route("getIP")]
        [HttpGet]
        public async Task<IActionResult> GetIpAddress()
        {
            var result = await _service.GetClientIpAddress();
            return Ok(result);
        }

        [HttpPost("createLogs")]
        public async Task<ActionResult<Response<int>>> CreateLogs([FromBody] LogsDto request)
        {
            var result = await _service.GetLogsCreate(request);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Response<int>>> Create([FromBody] UsuarioDto request)
        {
            var result = await _service.Create( request);
            return Ok(result);
        }
    }
}