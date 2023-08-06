using Dapper;
using Dapper.Contrib.Extensions;
using GerenciamentoInvestimentos.Domain.Interfaces.Repositories;
using GerenciamentoInvestimentos.Infrastructure.DataModel;
using GerenciamentoInvestimentos.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace GerenciamentoInvestimentos.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;
    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private NpgsqlConnection GetConn() => new(_configuration.GetConnectionString("postgres"));

    public IEnumerable<Domain.Entities.User> Get()
    {
        using NpgsqlConnection conn = GetConn();

        var users = conn.GetAll<User>();
        return users.ToDomain();
    }

    public Domain.Entities.User Get(long id)
    {
        using NpgsqlConnection conn = GetConn();

        var user = conn.Get<User>(id);
        return user.ToDomain();
    }

    public Domain.Entities.User? GetByEmail(string email)
    {
        var sql = @"SELECT * FROM invest_management.users WHERE email = :email";

        using NpgsqlConnection conn = GetConn();

        var user = conn.QueryFirstOrDefault<User>(sql, new { email });

        return user?.ToDomain();
    }

    public long Create(Domain.Entities.User user)
    {
        using NpgsqlConnection conn = GetConn();

        return conn.Insert(user.ToDataModel());
    }
}
