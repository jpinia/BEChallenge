using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DB
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Operacion> Operaciones { get; set;}
    }
}