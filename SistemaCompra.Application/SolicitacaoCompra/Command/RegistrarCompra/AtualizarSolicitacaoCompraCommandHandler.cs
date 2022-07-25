using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoAggregate;


namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class AtualizarSolicitacaoCompraCommandHandler : CommandHandler, IRequestHandler<AtualizarSolicitacaoCompraCommand, bool>
    {
        private readonly SolicitacaoAgg.ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public AtualizarSolicitacaoCompraCommandHandler(SolicitacaoAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;

        }

        public Task<bool> Handle(AtualizarSolicitacaoCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacao = _solicitacaoCompraRepository.Obter(request.SolicitacaoId);
            solicitacao.Atualizar(request.NomeFornecedor, request.Situacao, request.CondicaoPagamento);

            _solicitacaoCompraRepository.Atualizar(solicitacao);

            Commit();
            PublishEvents(solicitacao.Events);

            return Task.FromResult(true);

        }
    }
}
