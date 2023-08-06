using GerenciamentoInvestimentos.Application.Requests;

namespace GerenciamentoInvestimentos.Application.Mappers;

public static class OperationMapper
{
    public static Domain.Entities.Operation ToDomain(this InsertOperationRequest request, long portifolioId)
        => new(0, portifolioId, request.Type, request.Quantity, request.UnitValue, DateTime.UtcNow);
}
