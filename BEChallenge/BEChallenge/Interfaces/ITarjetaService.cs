using BEChallenge.DTOs;
using System.Threading;

namespace BEChallenge.Interfaces
{
    public interface ITarjetaService
    {
        public Task<SaldoDTO?> GetSaldoByNroTarjeta(string nroTarjeta);
        public Task<string> Retiro(string nroTarjeta, double monto);
    }
}
