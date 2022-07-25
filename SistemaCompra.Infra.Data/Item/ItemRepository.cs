using Microsoft.EntityFrameworkCore;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoAggregate;

namespace SistemaCompra.Infra.Data.Item
{
    public class ItemRepository : IItemRepository
    {
        private readonly SistemaCompraContext context;

        public ItemRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public List<SolicitacaoAgg.Item> Obter(Guid id)
        {
            return context.Set<SolicitacaoAgg.Item>().Where(c=> c.SolicitacaoCompraId == id).ToList();

        }
        
    }
}
