using GerenciamentoInvestimentos.Application.Requests;

namespace GerenciamentoInvestimentos.Application.Mappers;

public static class PortifolioMapper
{
    public static Domain.Entities.Portifolio ToDomain(this InsertOperationRequest request, Domain.Entities.User user)
        => new(0, user, request.Ticket, DateTime.UtcNow, null, request.Custodity, request.Wallet, null);
}
