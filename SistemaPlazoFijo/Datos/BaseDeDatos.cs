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

    }
}
