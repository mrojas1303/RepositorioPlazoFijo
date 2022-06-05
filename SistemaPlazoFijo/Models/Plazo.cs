namespace SistemaPlazoFijo.Models
{
    public class Plazo
    {
        public int Id { get; set; }
        public int Monto { get; set; }
        public int Dias { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaRetiro { get; set; }
        public Banco Banco { get; set; }

        public void setFechaIngreso()
        {
            FechaIngreso = DateTime.Now;

        }

        public void setFechaRetiro()
        {
            FechaRetiro = FechaIngreso.AddDays(Dias);

        }
    }
}

