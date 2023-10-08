using BEChallenge.Models;
using DB;

namespace BEChallenge.Interfaces
{
    public interface IOperacionService
    {
        public Task<PagedList<Operacion>> GetOperaciones(string nroTarjeta, int nroPagina);
    }
}
