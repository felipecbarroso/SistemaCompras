using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Application.SolicitacaoCompra.Query;
using System;
using System.Threading.Tasks;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("compra/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RegistrarCompra([FromBody] RegistrarCompraDto registrarCompraDto)
        {
            if (!(registrarCompraDto.ProdutoQuantidade.Count > 0))
            {
                return BadRequest("A compra deve possuir ao menos um item");
            }

            var registrarCompraCommand = new RegistrarSolicitacaoCompraCommand(registrarCompraDto);
            var result = await _mediator.Send(registrarCompraCommand);
            return StatusCode(
                (int)result.StatusCode, result.Success
                ? JsonConvert.SerializeObject(result.Response)
                : JsonConvert.SerializeObject(result.Error(result.StatusCode, result.Message)));
        }

        [HttpGet, Route("compra/obter/{id}")]
        public IActionResult ObterCompra(Guid id)
        {
            var query = new ObterSolicitacaoCompraQuery() { SolicitacaoCompraId = id };
            var solicitacaoCompraViewModel = _mediator.Send(query);

            return Ok(solicitacaoCompraViewModel);
           
        }

        [HttpPut, Route("compra/atualiza-solicitacao")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult AtualizarPreco([FromBody] AtualizarSolicitacaoCompraCommand atualizarSolicitacao)
        {
            _mediator.Send(atualizarSolicitacao);
            return Ok();

        }
    }
}
