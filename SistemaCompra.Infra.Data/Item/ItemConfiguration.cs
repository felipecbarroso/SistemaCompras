using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoAggregate;


namespace SistemaCompra.Infra.Data.Item
{
    class ItemConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.Item>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAgg.Item> builder)
        {
            builder.HasKey("Id");
            builder.HasOne(c => c.Produto);
            builder.OwnsOne(t => t.Subtotal, b => b.Property("Value").HasColumnName("Subtotal"));

        }
    }
}
