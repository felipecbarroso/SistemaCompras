using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoAggregate;
using SistemaCompraAgg = SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoAggregate;
using System.Collections.Generic;
using System;
using SistemaCompra.CrossCutting.Utils;
using System.Net;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarSolicitacaoCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarSolicitacaoCompraCommand, ApiResponse<bool>>
    {
        private readonly ISolicitacaoCompraRepository solicitacaoCompraRepository;
        private readonly SistemaCompraAgg.IProdutoRepository produtoRepository;
        public RegistrarSolicitacaoCompraCommandHandler
            (
            ISolicitacaoCompraRepository solicitacaoCompraRepository,
            SistemaCompraAgg.IProdutoRepository produtoRepository,
            IUnitOfWork uow, 
            IMediator mediator
            ) : base(uow, mediator)
        {
            this.solicitacaoCompraRepository = solicitacaoCompraRepository;
            this.produtoRepository = produtoRepository;
        }

        public Task<ApiResponse<bool>> Handle(RegistrarSolicitacaoCompraCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var listaItens = new List<Item>();

                foreach (var iten in request.ProdutoQuantidade)
                {
                    var produto = produtoRepository.ObterAtivo(iten.Key);
                    listaItens.Add(new Item(produto, iten.Value));
                }

                var solicitacaoCompra = new SolicitacaoAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor, listaItens);

                solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);

                Commit();
                PublishEvents(solicitacaoCompra.Events);

                return Task.FromResult(new ApiResponse<bool>().Ok(true));
            }
            
            catch(Exception e)
            {
                return Task.FromResult(new ApiResponse<bool>().Error(
                    HttpStatusCode.InternalServerError,
                    e.Message
                ));
            }

        }
    }
}
