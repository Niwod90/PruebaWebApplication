using AppPrueba.Application.Main.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AppPrueba.API.Main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PruebaController : ControllerBase
    {
        private readonly IPruebaAppService _appService;

        public PruebaController(IPruebaAppService appService)
        {
            _appService = appService;
        }

        [HttpGet(Name = "GetPrueba")]
        public IActionResult GetPrueba()
        {
            var result = _appService.GetPrueba();
            return Ok(result);
        }
    }
}
