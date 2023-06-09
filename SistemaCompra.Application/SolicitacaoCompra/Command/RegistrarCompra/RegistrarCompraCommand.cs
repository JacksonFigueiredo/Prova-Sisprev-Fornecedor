﻿using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public int CondPagamento { get; set; }
    }
}
