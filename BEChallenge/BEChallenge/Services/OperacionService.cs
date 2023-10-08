using BEChallenge.Interfaces;
using BEChallenge.Models;
using DB;

namespace BEChallenge.Services
{
    public class OperacionService : IOperacionService
    {
        private readonly BancoContext _context;

        public OperacionService(BancoContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Operacion>> GetOperaciones(string nroTarjeta, int nroPagina)
        {
            var operaciones = _context.Operaciones.Where(x => x.nroTarjeta == nroTarjeta);
            return await PagedList<Operacion>.CreateAsync(operaciones, nroPagina, 10);
        }
    }
}
