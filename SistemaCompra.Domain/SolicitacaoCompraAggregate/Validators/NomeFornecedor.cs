﻿using SistemaCompra.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate.Validators
{
    public class NomeFornecedor
    {
        public string Nome { get; }

        private NomeFornecedor() { }

        public NomeFornecedor(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (nome.Length < 10) throw new BusinessRuleException("Nome de fornecedor deve ter pelo menos 10 caracteres.");

            Nome = nome;
        }
    }
}
