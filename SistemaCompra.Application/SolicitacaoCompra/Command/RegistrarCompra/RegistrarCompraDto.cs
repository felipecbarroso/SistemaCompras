using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraDto
    {
        public string NomeFornecedor { get; set; }
        public string UsuarioSolicitante { get; set; }
        public List<KeyValuePair<Guid, int>> ProdutoQuantidade { get; set; }

        public RegistrarCompraDto()
        {

        }

    }
}
