using Microsoft.AspNetCore.Mvc;
using WebApi93.Service.Services;
using WebApi93.Service.IServices;
using Microsoft.AspNetCore.Identity;
namespace WebApi93.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;

        public AutoresController (IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok( await _autorServices.GetAutores() );
        }

    }

}
