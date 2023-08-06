using GerenciamentoInvestimentos.Application.Mappers;
using GerenciamentoInvestimentos.Application.Requests;
using GerenciamentoInvestimentos.Application.Responses;
using GerenciamentoInvestimentos.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace GerenciamentoInvestimentos.Application.UseCases;

public class OperationUseCases
{
    private readonly IUserService _userService;
    private readonly IPortifolioService _portifolioService;
    private readonly IOperationService _operationService;
    private readonly ILogger<OperationUseCases> _logger;
    public OperationUseCases(IUserService userService,
                             IPortifolioService portifolioService,
                             IOperationService operationService,
                             ILogger<OperationUseCases> logger)
    {
        _userService = userService;
        _portifolioService = portifolioService;
        _operationService = operationService;
        _logger = logger;
    }

    public OperationResponse InsertBuyOperation(InsertOperationRequest request, long userId)
    {
        _logger.LogInformation("Buscando usuário no banco de dados");
        var user = _userService.GetUser(userId);

        var portifolioRequest = request.ToDomain(user);

        _logger.LogInformation("Buscando portifólio no banco de dados");
        var portifolioId = _portifolioService.GetIdByFilter(userId, portifolioRequest.Ticket, portifolioRequest.Custody, portifolioRequest.Wallet);
        if (portifolioId < 1)
        {
            _logger.LogInformation("Portifólio não existe. Criando novo portifólio");
            portifolioId = _portifolioService.Create(portifolioRequest);
        }

        var operationRequest = request.ToDomain(portifolioId: portifolioId);

        _logger.LogInformation("Inserindo nova operação");
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
