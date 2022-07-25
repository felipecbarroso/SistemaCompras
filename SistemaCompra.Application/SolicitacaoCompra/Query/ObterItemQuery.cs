using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterItemQuery : IRequest<ObterItemViewModel>
    {
        public Guid SolicitacaoCompraId { get; set; }
    }
}
