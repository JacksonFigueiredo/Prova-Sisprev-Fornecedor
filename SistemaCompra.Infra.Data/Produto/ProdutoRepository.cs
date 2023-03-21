using System;
using System.Linq;
using SistemaCompra.Domain.ProdutoAggregate.Interfaces;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SistemaCompraContext context;

        public ProdutoRepository(SistemaCompraContext context)  {
            this.context = context;
        }

        public void Atualizar(ProdutoAgg.Entities.Produto entity)
        {
            context.Set<ProdutoAgg.Entities.Produto>().Update(entity);
        }

        public void Excluir(ProdutoAgg.Entities.Produto entity)
        {
            context.Set<ProdutoAgg.Entities.Produto>().Remove(entity);
        }

        public ProdutoAgg.Entities.Produto Obter(Guid id)
        {
            return context.Set<ProdutoAgg.Entities.Produto>().Where(c=> c.Id == id).FirstOrDefault();
        }

        public void Registrar(ProdutoAgg.Entities.Produto entity)
        {
            context.Set<ProdutoAgg.Entities.Produto>().Add(entity);
        }
    }
}
