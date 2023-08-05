using GerenciamentoInvestimentos.Infrastructure.DataIntegration.Brapi.Responses;
using Refit;

namespace GerenciamentoInvestimentos.Infrastructure.Integration;

public interface IBrapiIntegration
{
    [Get("/api/quote/{tickers}")]
    public Task<IApiResponse<GetQuoteResponse>> GetQuote(string tickers);
}
