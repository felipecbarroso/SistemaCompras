using MediatR;
using SistemaCompra.Domain.SolicitacaoAggregate;
using System;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class AtualizarSolicitacaoCompraCommand : IRequest<bool>
    {
        public Guid SolicitacaoId { get; set; }
        public string NomeFornecedor { get; set; }
        public Situacao Situacao { get; set; }
        public int CondicaoPagamento { get; set; }
    }
}
