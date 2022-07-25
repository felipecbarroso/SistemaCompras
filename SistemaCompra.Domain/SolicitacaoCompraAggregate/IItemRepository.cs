using SistemaCompra.Domain.SolicitacaoAggregate;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface IItemRepository
    {
        List<Item> Obter(Guid id);

    }
}
