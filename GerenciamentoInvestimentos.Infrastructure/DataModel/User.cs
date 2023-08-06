using Dapper.Contrib.Extensions;

namespace GerenciamentoInvestimentos.Infrastructure.DataModel;

[Table("invest_management.users")]
public class User
{
    [Key]
    public long id { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public string password { get; set; }
}
