using BEChallenge.Interfaces;
using BEChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;

        public LoginController(IAutorizacionService autorizacionService)
        {
            _autorizacionService = autorizacionService;
        }

        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AutorizacionRequest autorizacion) { 
            var resultado_autorizacion = await _autorizacionService.DevolverToken(autorizacion);
            if(resultado_autorizacion== null)
            {
                return Unauthorized();
            }

            return Ok(resultado_autorizacion);

        }
    }
}
