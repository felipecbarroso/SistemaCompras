using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaCompra.API.SolicitacaoCompra;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.CrossCutting.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace SistemaCompra.Domain.Test.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompraControllerTest
    {
        private Mock<IMediator> mediator;

        [Fact]
        public void RegistrarCompra_CompraSemItens_Falha()
        {
            var controller = CriarController();
            var compraDto = new RegistrarCompraDto() 
            { 
                NomeFornecedor = "Teste Dos Santos",
                UsuarioSolicitante = "Jose da Silva Teste",
                ProdutoQuantidade = new List<KeyValuePair<Guid, int>>()
            };

            var result = controller.RegistrarCompra(compraDto).Result;

            Assert.IsType<BadRequestObjectResult>(result);

        }

        private SolicitacaoCompraController CriarController()
        {
            mediator = new Mock<IMediator>();
            return new SolicitacaoCompraController(mediator.Object);
        }

    }
}
