using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, List<Item> itens)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            Itens = itens;
            TotalGeral = CalcularTotal(itens);
            CondicaoPagamento = RegistrarCondicaoPagamento(TotalGeral.Value);

        }

        public void Atualizar(string nomeFornecedor, Situacao situacao, int condicaoPagamento)
        {
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Situacao = situacao;
            CondicaoPagamento = new CondicaoPagamento(condicaoPagamento);

        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        private static Money CalcularTotal(List<Item> itens)
        {
            decimal valorTotal = 0;
            foreach(var item in itens)
            {
                valorTotal += item.Subtotal.Value;
            }

            return new Money(valorTotal);

        }

        public CondicaoPagamento RegistrarCondicaoPagamento(decimal valorTotal)
        {
            if (valorTotal > 50000)
                return new CondicaoPagamento(30);
            return new CondicaoPagamento(0);
        }
    }
}
