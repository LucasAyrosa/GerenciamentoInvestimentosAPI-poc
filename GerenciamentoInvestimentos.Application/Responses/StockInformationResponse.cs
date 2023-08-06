namespace GerenciamentoInvestimentos.Application.Responses;

public class StockInformationResponse
{
    public string Symbol { get; set; }
    public string ShortName { get; set; }
    public string LongName { get; set; }
    public string Currency { get; set; }
    public decimal RegularMarketPrice { get; set; }
    public DateTime RegularMarketTime { get; set; }
}
