using SistemaCompra.Domain.SolicitacaoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterItemViewModel
    {
        public List<Guid> Id { get; set; }

        public ObterItemViewModel(List<Item> itens)
        {
            Id = new List<Guid>();
            foreach(var item in itens)
            {
                Id.Add(item.Id);
            }
        }
    }
}
