using MediatR;
using SistemaCompra.Domain.ProdutoAggregate.Interfaces;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Application.Produto.Command.RegistrarProduto
{
    public class RegistrarProdutoCommandHandler : CommandHandler, IRequestHandler<RegistrarProdutoCommand, bool>
    {
        private readonly IProdutoRepository produtoRepository;

        public RegistrarProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new ProdutoAgg.Entities.Produto(request.Nome, request.Descricao, request.Categoria, request.Preco);
            produtoRepository.Registrar(produto);

            Commit();
            PublishEvents(produto.Events);

            return Task.FromResult(true);
        }
    }
}
