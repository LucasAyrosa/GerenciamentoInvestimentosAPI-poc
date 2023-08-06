using Dapper;
using Dapper.Contrib.Extensions;
using GerenciamentoInvestimentos.Domain.Interfaces.Repositories;
using GerenciamentoInvestimentos.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace GerenciamentoInvestimentos.Infrastructure.Repositories;

public class PortifolioRepository : IPortifolioRepository
{
    private readonly IConfiguration _configuration;
    public PortifolioRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private NpgsqlConnection GetConn() => new(_configuration.GetConnectionString("postgres"));

    public long Create(Domain.Entities.Portifolio portifolio)
    {
        using NpgsqlConnection conn = GetConn();

        return conn.Insert(portifolio.ToDataModel());
    }

    public long GetIdByFilter(long userId, string ticket, string? custody, string? wallet)
    {
        using NpgsqlConnection conn = GetConn();

        string query = @"select id
                        from invest_management.portifolio
                        where user_id = :userId
                        and ticket  = :ticket
                        and custody = :custody
                        and wallet = :wallet";

        return conn.QueryFirstOrDefault<int>(query, new { userId, ticket, custody, wallet });
    }
}
