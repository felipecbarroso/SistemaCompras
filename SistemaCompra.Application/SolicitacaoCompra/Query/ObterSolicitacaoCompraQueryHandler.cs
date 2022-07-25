using AutoMapper;
using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterSolicitacaoCompraQueryHandler : CommandHandler, IRequestHandler<ObterSolicitacaoCompraQuery, ObterSolicitacaoCompraViewModel>
    {
        private readonly SolicitacaoAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository;

        public ObterSolicitacaoCompraQueryHandler(SolicitacaoAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<ObterSolicitacaoCompraViewModel> Handle(ObterSolicitacaoCompraQuery request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = solicitacaoCompraRepository.Obter(request.SolicitacaoCompraId);

            var itens = Send(new ObterItemQuery() { SolicitacaoCompraId = solicitacaoCompra.Id }).Result;

            var response = new ObterSolicitacaoCompraViewModel(solicitacaoCompra);
            response.Itens = itens.Id;

            return Task.FromResult(response);
        }
    }
}
