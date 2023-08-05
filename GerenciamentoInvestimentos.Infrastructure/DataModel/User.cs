using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoInvestimentos.Infrastructure.DataModel;

[Dapper.Contrib.Extensions.Table("invest_management.users")]
public class User
{
    [Key]
    public int id { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public string password { get; set; }
}
