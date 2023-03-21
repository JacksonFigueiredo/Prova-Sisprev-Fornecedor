using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoAgg.Entities.Produto>
    {
        public void Configure(EntityTypeBuilder<ProdutoAgg.Entities.Produto> builder)
        {
            builder.ToTable("Produto");
            builder.OwnsOne(c => c.Preco, b => b.Property("Value").HasColumnName("Preco"));
        }
    }
}
