using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;


namespace projeto_vwndas.Projeto_Vendas_API.Infrastructure.Data.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>

    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            {
                builder.ToTable("Produto");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            }
        }
    }
}
