namespace BEChallenge.DTOs
{
    public class SaldoDTO
    {
        public string nombreUsuario { get; set; }
        public int nroCuenta { get; set; }
        public double saldoActual { get; set; }
        public DateTime? fechaUltimaExtraccion { get; set; }

    }
}
