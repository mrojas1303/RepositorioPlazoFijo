namespace SistemaPlazoFijo.Models
{
    public class Cliente
    {
        // atributos
        public int Id { get; set; }
        public int Dni { get; set; } = 0;
        public String Apellido { get; set; } = "";
        public String Nombre { get; set; } = "";
        public String Email { get; set; } = "";
        public String Password { get; set; } = "";
        public String TipoCliente { get; set; } = "";
    }
}
