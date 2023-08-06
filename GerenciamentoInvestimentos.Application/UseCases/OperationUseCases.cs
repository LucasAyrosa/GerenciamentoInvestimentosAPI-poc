using GerenciamentoInvestimentos.Application.Mappers;
using GerenciamentoInvestimentos.Application.Requests;
using GerenciamentoInvestimentos.Application.Responses;
using GerenciamentoInvestimentos.Domain.Interfaces.Services;

namespace GerenciamentoInvestimentos.Application.UseCases;

public class OperationUseCases
{
    private readonly IUserService _userService;
    private readonly IPortifolioService _portifolioService;
    private readonly IOperationService _operationService;
    public OperationUseCases(IUserService userService, IPortifolioService portifolioService, IOperationService operationService)
    {
        _userService = userService;
        _portifolioService = portifolioService;
        _operationService = operationService;
    }

    public OperationResponse InsertBuyOperation(InsertOperationRequest request, long userId)
    {
        var user = _userService.GetUser(userId);
        var portifolioRequest = request.ToDomain(user);

        var portifolioId = _portifolioService.GetIdByFilter(userId, portifolioRequest.Ticket, portifolioRequest.Custody, portifolioRequest.Wallet);
        if (portifolioId < 1)
        {
            portifolioId = _portifolioService.Create(portifolioRequest);
        }

        var operationRequest = request.ToDomain(portifolioId: portifolioId);
        _operationService.Create(operationRequest);

        // TODO: implementar mensageria para processamento de posição assincrona

        return new()
        {
            Ticket = portifolioRequest.Ticket,
            Custodity = portifolioRequest.Custody,
            Wallet = portifolioRequest.Wallet,
            Quantity = operationRequest.Quantity,
            Type = operationRequest.Type,
            UnitValue = operationRequest.UnitValue
        };
    }

    public OperationResponse InsertSellOperation(InsertOperationRequest request, long userId)
    {
        throw new NotImplementedException();
    }
}
