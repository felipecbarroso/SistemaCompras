using MediatR;
using SistemaCompra.CrossCutting.Utils;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarSolicitacaoCompraCommand : IRequest<ApiResponse<bool>>
    {
        public string NomeFornecedor { get; set; }
        public string UsuarioSolicitante { get; set; }
        public List<KeyValuePair<Guid, int>> ProdutoQuantidade { get; set; }

        public RegistrarSolicitacaoCompraCommand(RegistrarCompraDto compraDto)
        {
            NomeFornecedor = compraDto.NomeFornecedor;
            UsuarioSolicitante = compraDto.UsuarioSolicitante;
            ProdutoQuantidade = compraDto.ProdutoQuantidade;
        }
    }
}
