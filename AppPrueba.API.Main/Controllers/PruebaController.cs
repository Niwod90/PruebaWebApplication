using AppPrueba.Application.Main.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AppPrueba.API.Main.Controllers
{
    [ApiController]
    [Route("service")]
    public class PruebaController : ControllerBase
    {
        private readonly IPruebaAppService _appService;

        public PruebaController(IPruebaAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        [Route("/GetFirstUsers")]
        public IActionResult GetFirstUsers()
        {
            var result = _appService.GetFirstUsers();
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetPrueba")]
        public IActionResult GetPrueba()
        {
            var result = _appService.GetPrueba();
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetUser")]
        public async Task<IActionResult> GetUserAsync()
        {
            var result = await _appService.GetPruebaAsync();
            return Ok(result);
        }
    }
}
