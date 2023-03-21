using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate.Entities;
using SistemaCompra.Domain.ProdutoAggregate.Events;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Entities;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Enums;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate.Entities
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }

        public CondicaoPagamento CondPagamento { get; private set; }
        public Enums.Situacao Situacao { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, int condicaoPagamento)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            CondPagamento = new CondicaoPagamento(condicaoPagamento);
            Situacao = Enums.Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (TotalGeral.Value > 50000)
            {
                CondPagamento = new CondicaoPagamento(30);
            }

            if (itens.Count() <= 0)
            {
                throw new ArgumentNullException(nameof(Itens));
            }

            AddEvent(new CompraRegistradaEvent(Guid.NewGuid(),itens, TotalGeral.Value));
        }
    }
}
