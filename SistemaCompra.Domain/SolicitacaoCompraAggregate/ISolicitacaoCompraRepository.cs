using System;

namespace SistemaCompra.Domain.SolicitacaoAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        SolicitacaoCompra Obter(Guid id);
        void Atualizar(SolicitacaoCompra entity);
        void Excluir(SolicitacaoCompra entity);
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
