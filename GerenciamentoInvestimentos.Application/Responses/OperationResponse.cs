using GerenciamentoInvestimentos.Domain.Enums;

namespace GerenciamentoInvestimentos.Application.Responses;

public class OperationResponse
{
    public string Ticket { get; set; }

    public string Custodity { get; set; }

    public string Wallet { get; set; }

    public EOperationType Type { get; set; }

    public int Quantity { get; set; }

    public decimal UnitValue { get; set; }
}
