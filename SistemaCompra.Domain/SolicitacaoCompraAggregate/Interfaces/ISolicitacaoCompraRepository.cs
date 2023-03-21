using SistemaCompra.Domain.SolicitacaoCompraAggregate.Entities;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate.Interfaces
{
    public interface ISolicitacaoCompraRepository
    {
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
