using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;

namespace SistemaCompra.API.SolicitacaoCompra
{

    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost, Route("solicitacaocompra/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarCompra([FromBody] RegistrarCompraCommand registrarCompraCommand)
        {
            _mediator.Send(registrarCompraCommand);
            return StatusCode(201);
        }

    }
}
