using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Tarjeta
    {
        [Key]
        public string nroTarjeta { get; set; }
        public int PIN { get; set; }
        public string nombreUsuario { get; set; }
        public int nroCuenta { get; set; }
        public double saldoActual { get; set; }
        public DateTime? fechaUltimaExtraccion { get; set; }
        public int intentosFallidos { get; set; }
        public bool estaBloqueada { get; set; }
    }
}
