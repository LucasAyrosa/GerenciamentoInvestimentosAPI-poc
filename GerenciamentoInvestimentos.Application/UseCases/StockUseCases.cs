using GerenciamentoInvestimentos.Application.Mappers;
using GerenciamentoInvestimentos.Application.Responses;
using GerenciamentoInvestimentos.Domain.Exceptions;
using GerenciamentoInvestimentos.Infrastructure.Integration;

namespace GerenciamentoInvestimentos.Application.UseCases;

public class StockUseCases
{
    private readonly IBrapiIntegration _brapiIntegration;
    public StockUseCases(IBrapiIntegration brapiIntegration)
    {
        _brapiIntegration = brapiIntegration;
    }

    public async Task<StockInformationResponse?> GetStockInformation(string ticket)
    {
        var brapiResponse = await _brapiIntegration.GetQuote(ticket);
        if (brapiResponse.IsSuccessStatusCode)
        {
            return brapiResponse.Content?.Results
                .FirstOrDefault(s => s.Symbol == ticket)?
                .ToResponse();
        }
        else throw new IntegrationException("Não houve sucesso na integração para buscar informação de cotação");
    }
}
