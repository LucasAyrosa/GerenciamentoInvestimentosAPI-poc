namespace GerenciamentoInvestimentos.Infrastructure.DataIntegration.Brapi.Responses;

public class TicketInfo
{
    public string Symbol { get; set; }
    public string ShortName { get; set; }
    public string LongName { get; set; }
    public string Currency { get; set; }
    public decimal RegularMarketPrice { get; set; }
    public decimal RegularMarketDayHigh { get; set; }
    public decimal RegularMarketDayLow { get; set; }
    public string RegularMarketDayRange { get; set; }
    public decimal RegularMarketChange { get; set; }
    public decimal RegularMarketChangePercent { get; set; }
    public DateTime RegularMarketTime { get; set; }
    public long MarketCap { get; set; }
    public long RegularMarketVolume { get; set; }
    public decimal RegularMarketPreviousClose { get; set; }
    public decimal RegularMarketOpen { get; set; }
    public long AverageDailyVolume10Day { get; set; }
    public long AverageDailyVolume3Month { get; set; }
    public decimal FiftyTwoWeekLowChange { get; set; }
    public decimal FiftyTwoWeekLowChangePercent { get; set; }
    public string FiftyTwoWeekRange { get; set; }
    public decimal FiftyTwoWeekHighChange { get; set; }
    public decimal FiftyTwoWeekHighChangePercent { get; set; }
    public decimal FiftyTwoWeekLow { get; set; }
    public decimal FiftyTwoWeekHigh { get; set; }
    public decimal TwoHundredDayAverage { get; set; }
    public decimal TwoHundredDayAverageChange { get; set; }
    public decimal TwoHundredDayAverageChangePercent { get; set; }
}
