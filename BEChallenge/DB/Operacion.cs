using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public enum tipoOperacion : int
    {
        Extraccion = 1,
        Deposito = 2
    }
    public class Operacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOperacion {get; set;}
        public string nroTarjeta { get; set; }
        [ForeignKey("nroTarjeta")]
        public double monto { get; set; }

        public tipoOperacion tipoOperacion { get; set;}
    }

    
}
