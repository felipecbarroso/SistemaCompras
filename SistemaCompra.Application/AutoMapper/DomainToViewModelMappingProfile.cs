using AutoMapper;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Query;
using System.Collections.Generic;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompraAgg = SistemaCompra.Domain.SolicitacaoAggregate;

namespace SistemaCompra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>()
                .ForMember(d=> d.Preco, o=> o.MapFrom(src=> src.Preco.Value));

            //CreateMap<SistemaCompraAgg.SolicitacaoCompra, ObterSolicitacaoCompraViewModel>()
            //    .ForMember(d => d.TotalGeral, o => o.MapFrom(src => src.TotalGeral.Value))
            //    .ForMember(d => d.NomeFornecedor, o => o.MapFrom(src => src.NomeFornecedor.Nome))
            //    .ForMember(d => d.UsuarioSolicitante, o => o.MapFrom(src => src.UsuarioSolicitante.Nome))
            //    .ForMember(d => d.CondicaoPagamento, o => o.MapFrom(src => src.CondicaoPagamento.Valor));

        }
    }
}
