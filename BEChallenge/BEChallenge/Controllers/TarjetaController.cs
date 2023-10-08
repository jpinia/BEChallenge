using BEChallenge.DTOs;
using BEChallenge.Interfaces;
using DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TarjetaController : ControllerBase
    {
        private readonly ITarjetaService _tarjetaService;

        public TarjetaController( ITarjetaService tarjetaService)
        {
            _tarjetaService = tarjetaService;
        }


        [HttpGet("Saldo")]
        public async Task<IActionResult> GetSaldoByNroTarjeta(string nroTarjeta)
        {
            var saldo= await _tarjetaService.GetSaldoByNroTarjeta(nroTarjeta);

            if(saldo!=null)
                return Ok(saldo);

            return NotFound();
        }

        [HttpPost("Retiro")]
        public async Task<IActionResult> Retiro(string nroTarjeta, double monto)
        {
            var retiro = await _tarjetaService.Retiro(nroTarjeta, monto);

            if(retiro.Contains("Error"))
                return NotFound(retiro);

            return Ok(retiro);

        }
    }
}
