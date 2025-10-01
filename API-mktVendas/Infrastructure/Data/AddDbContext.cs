using Microsoft.EntityFrameworkCore;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using System.Collections.Generic;


namespace API_mktVendas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<produto> produto { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}