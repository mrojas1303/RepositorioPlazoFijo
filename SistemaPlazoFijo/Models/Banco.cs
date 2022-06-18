namespace SistemaPlazoFijo.Models
{
    public class Banco
    {
        public int id { get; set; }
        
        public String RazonSocial { get; set; }

        public String Direccion { get; set; }

        public String Localidad { get; set; }

        public decimal Porcentaje { get; set; }

        public int saldo { get; set; }

    }
}
