using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Interfaces;
using SistemaCompra.Infra.Data.SolicitacaoCompra;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using CompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    internal class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var produto = new CompraAgg.Entities.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor, request.CondPagamento);
            _solicitacaoCompraRepository.RegistrarCompra(produto);

            Commit();
            PublishEvents(produto.Events);

            return Task.FromResult(true);
        }
    }
}
