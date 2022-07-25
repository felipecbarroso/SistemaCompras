using SistemaCompra.Domain.SolicitacaoAggregate;
using System;
using System.Collections.Generic;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoAggregate;


namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterSolicitacaoCompraViewModel
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public List<Guid> Itens { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalGeral { get; set; }
        public Situacao Situacao { get; set; }
        public int CondicaoPagamento { get; set; }

        public ObterSolicitacaoCompraViewModel()
        {

        }

        public ObterSolicitacaoCompraViewModel(SolicitacaoAgg.SolicitacaoCompra solicitacaoCompra)
        {
            UsuarioSolicitante = solicitacaoCompra.UsuarioSolicitante.Nome;
            NomeFornecedor = solicitacaoCompra.NomeFornecedor.Nome;
            Data = solicitacaoCompra.Data;
            TotalGeral = solicitacaoCompra.TotalGeral.Value;
            Situacao = solicitacaoCompra.Situacao;
            CondicaoPagamento = solicitacaoCompra.CondicaoPagamento.Valor;
        }

    }
}
