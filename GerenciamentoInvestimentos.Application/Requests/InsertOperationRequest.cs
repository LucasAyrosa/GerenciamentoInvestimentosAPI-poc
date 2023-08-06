using GerenciamentoInvestimentos.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoInvestimentos.Application.Requests;

public class InsertOperationRequest
{
    [Required]
    public string Ticket { get; set; }

    public string Custodity { get; set; }

    public string Wallet { get; set; }

    [Required]
    public EOperationType Type { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal UnitValue { get; set; }
}
