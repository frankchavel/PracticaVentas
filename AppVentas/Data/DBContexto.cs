using AppVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace AppVentas.Data
{
    public class DBContexto: DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
        }
    }
}
