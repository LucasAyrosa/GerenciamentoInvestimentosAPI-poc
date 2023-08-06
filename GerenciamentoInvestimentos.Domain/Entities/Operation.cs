using GerenciamentoInvestimentos.Domain.Enums;

namespace GerenciamentoInvestimentos.Domain.Entities;

public class Operation
{
    public Operation(long id,
                     long portifolioId,
                     EOperationType type,
                     int quantity,
                     decimal unitValue,
                     DateTime date)
    {
        Id = id;
        PortifolioId = portifolioId;
        Type = type;
        Quantity = quantity;
        UnitValue = unitValue;
        Date = date;
    }

    public long Id { get; private set; }
    public long PortifolioId { get; private set; }
    public EOperationType Type { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitValue { get; private set; }
    public DateTime Date { get; private set; }
}
