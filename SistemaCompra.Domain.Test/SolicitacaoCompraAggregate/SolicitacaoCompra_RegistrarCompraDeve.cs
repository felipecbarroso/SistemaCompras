using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoAggregate;
using System.Collections.Generic;
using Xunit;

namespace SistemaCompra.Domain.Test.SolicitacaoAggregate
{
    public class SolicitacaoCompra_RegistrarCompraDeve
    {
        [Fact]
        public void DefinirPrazo30DiasAoComprarMais50mil()
        {
            var produto = new Produto("Cedro", "Transversal 3/3", Categoria.Madeira.ToString(), 1001);
            var itens = new List<Item>() {new Item(produto, 50) };
            var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth", itens);

            Assert.Equal(30, solicitacao.CondicaoPagamento.Valor);
        }

        [Fact]
        public void NotificarErroQuandoNaoInformarItensCompra()
        {
            //Dado
            //var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth");
            var produto = new Produto();
            //solicitacao.AdicionarItem(produto, 0);

            //Quando 
            //var ex = Assert.Throws<BusinessRuleException>(() => solicitacao.RegistrarCompra());

            //Então
            //Assert.Equal("A solicitação de compra deve possuir itens!", ex.Message);
        }
    }
}
