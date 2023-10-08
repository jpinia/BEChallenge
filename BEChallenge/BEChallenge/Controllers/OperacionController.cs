using BEChallenge.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OperacionController : ControllerBase
    {
        private readonly IOperacionService _operacionService;

        public OperacionController(IOperacionService operacionService)
        {
            _operacionService = operacionService;
        }

        [HttpGet("Historial")]
        public async Task<IActionResult> GetOperaciones(string nroTarjeta, int nroPagina)
        {
            var operacionesPaginadas = await _operacionService.GetOperaciones(nroTarjeta, nroPagina);

            if (operacionesPaginadas != null)
                return Ok(operacionesPaginadas);

            return NotFound();
        }
    }
}
