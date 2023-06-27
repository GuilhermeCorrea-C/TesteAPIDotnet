using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Map;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class SistemaFeriadosDBContext : DbContext
    {
        public SistemaFeriadosDBContext(DbContextOptions<SistemaFeriadosDBContext> options):base(options)
        {     
        }

        public DbSet<FeriadoModel> Feriados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FeriadoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
