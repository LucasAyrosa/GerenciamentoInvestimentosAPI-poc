using Dapper.Contrib.Extensions;

namespace GerenciamentoInvestimentos.Infrastructure.DataModel;

[Table("invest_management.portifolio")]
public class Portifolio
{
    [Key]
    public long id { get; set; }

    public long user_id { get; set; }

    public string ticket { get; set; }

    public DateTime opening_date { get; set; }

    public DateTime? closing_date { get; set; }

    public string custody { get; set; }

    public string wallet { get; set; }
}
