using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Infra.Data.Produto;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Entities.Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoAgg.Entities.Produto>()
         .HasData(
             new ProdutoAgg.Entities.Produto("Produto01", "Descricao01", "Madeira", 100)
         );

            modelBuilder.Entity<ProdutoAgg.Entities.Produto>(entity =>
            {
                entity.HasOne(p => p.Preco)
                      .WithOne()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=SistemaCompraDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
