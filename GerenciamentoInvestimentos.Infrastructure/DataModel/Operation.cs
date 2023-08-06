using Dapper.Contrib.Extensions;

namespace GerenciamentoInvestimentos.Infrastructure.DataModel;

[Table("invest_management.operations")]
public class Operation
{
    [Key]
    public long id { get; set; }

    public long portifolio_id { get; set; }

    public int type { get; set; }

    public int quantity { get; set; }

    public decimal unit_value { get; set; }

    public DateTime date { get; set; }
}
