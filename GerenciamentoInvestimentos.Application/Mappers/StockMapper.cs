using GerenciamentoInvestimentos.Application.Responses;
using GerenciamentoInvestimentos.Infrastructure.DataIntegration.Brapi.Responses;

namespace GerenciamentoInvestimentos.Application.Mappers;

public static class StockMapper
{
    public static StockInformationResponse ToResponse(this TicketInfo integrationResponse)
        => new()
        {
            Symbol = integrationResponse.Symbol,
            ShortName = integrationResponse.ShortName,
            LongName = integrationResponse.LongName,
            Currency = integrationResponse.Currency,
            RegularMarketPrice = integrationResponse.RegularMarketPrice,
            RegularMarketTime = integrationResponse.RegularMarketTime,
        };
}
