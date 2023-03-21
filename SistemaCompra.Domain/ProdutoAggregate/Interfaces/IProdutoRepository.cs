using System;
using System.Linq;
using SistemaCompra.Domain.ProdutoAggregate.Entities;

namespace SistemaCompra.Domain.ProdutoAggregate.Interfaces
{
    public interface IProdutoRepository
    {
        Produto Obter(Guid id);
        void Registrar(Produto entity);
        void Atualizar(Produto entity);
        void Excluir(Produto entity);
    }
}
