using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");
            builder.HasOne(u => u.UsuarioSolicitante);
            builder.HasOne(n => n.NomeFornecedor);
            builder.HasMany(i => i.Itens);
            builder.OwnsOne(t => t.TotalGeral, b => b.Property("Value").HasColumnName("Preco"));
            builder.OwnsOne(t => t.CondicaoPagamento, b => b.Property("Value").HasColumnName("CondicaoPagamento"));
        }
    }
}
