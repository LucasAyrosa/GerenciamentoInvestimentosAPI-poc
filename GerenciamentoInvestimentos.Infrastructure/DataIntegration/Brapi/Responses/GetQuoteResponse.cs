namespace GerenciamentoInvestimentos.Infrastructure.DataIntegration.Brapi.Responses;

public class GetQuoteResponse
{
    public IEnumerable<TicketInfo> Results { get; set; }
    public DateTime RequestedAt { get; set; }
}
