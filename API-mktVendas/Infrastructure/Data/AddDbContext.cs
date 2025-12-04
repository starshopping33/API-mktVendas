using API_mktVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;


namespace API_mktVendas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Produto> Produto { get; set; } 

        public DbSet <Categoria> Categoria { get; set; }
        public DbSet<CategId> CateId { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategId>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }

  
}
