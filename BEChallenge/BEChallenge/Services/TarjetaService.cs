using BEChallenge.DTOs;
using BEChallenge.Interfaces;
using DB;
using Microsoft.AspNetCore.Mvc;

namespace BEChallenge.Services
{
    public class TarjetaService : ITarjetaService
    {
        private readonly BancoContext _context;

        public TarjetaService(BancoContext context)
        {
            _context = context;
        }

        public async Task<SaldoDTO?> GetSaldoByNroTarjeta(string nroTarjeta)
        {
            // Buscar la tarjeta en la base de datos
            var tarjeta = _context.Tarjetas.FirstOrDefault(x => x.nroTarjeta == nroTarjeta);

            // Verificar si la tarjeta se encontró
            if (tarjeta != null)
            {
                // Crear un objeto SaldoDTO y asignar los valores
                var saldo = new SaldoDTO()
                {
                    nombreUsuario = tarjeta.nombreUsuario,
                    nroCuenta = tarjeta.nroCuenta,
                    saldoActual = tarjeta.saldoActual,
                    fechaUltimaExtraccion = tarjeta.fechaUltimaExtraccion
                };

                return saldo;
            }

            return null;
        }

        public async Task<string> Retiro(string nroTarjeta, double monto) {
            var tarjeta = _context.Tarjetas.FirstOrDefault(x => x.nroTarjeta == nroTarjeta);

            if (tarjeta.saldoActual < monto)
                return "Error: No dispone de monto suficiente";

            tarjeta.saldoActual = tarjeta.saldoActual - monto;
            tarjeta.fechaUltimaExtraccion = DateTime.Now;
            _context.Tarjetas.Update(tarjeta);
            _context.SaveChanges();

            var operacion = new Operacion { monto= monto , nroTarjeta = nroTarjeta, tipoOperacion = tipoOperacion.Extraccion};
            _context.Operaciones.Add(operacion);
            _context.SaveChanges();

            return "Se retiro: " + monto + " correctamente.";
        }
    }
}
