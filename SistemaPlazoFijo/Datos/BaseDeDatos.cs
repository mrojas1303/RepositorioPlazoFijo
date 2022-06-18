using Microsoft.EntityFrameworkCore;
using SistemaPlazoFijo.Models;

namespace SistemaPlazoFijo.Datos
{
    public class BaseDeDatos : DbContext
    {
        public BaseDeDatos(DbContextOptions opciones) : base(opciones)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Plazo> Plazos { get; set; }

        public DbSet<Banco> Bancos { get; set; }

        public DbSet<Login>? Logins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1CM86AD\CAROLINAPAZ;Database=PLAZO_FIJO_V2;Trusted_Connection=True;MultipleActiveResultSets=true;");

        }
    }
}
