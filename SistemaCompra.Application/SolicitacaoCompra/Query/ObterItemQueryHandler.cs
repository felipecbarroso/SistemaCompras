using AutoMapper;
using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterItemQueryHandler : CommandHandler, IRequestHandler<ObterItemQuery, ObterItemViewModel>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ObterItemQueryHandler(IItemRepository itemRepository, IMapper mapper, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public Task<ObterItemViewModel> Handle(ObterItemQuery request, CancellationToken cancellationToken)
        {
            var itens = _itemRepository.Obter(request.SolicitacaoCompraId);
            var response = new ObterItemViewModel(itens);

            return Task.FromResult(response);

        }
    }
}
