using Dapper.Contrib.Extensions;
using GerenciamentoInvestimentos.Domain.Interfaces.Repositories;
using GerenciamentoInvestimentos.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace GerenciamentoInvestimentos.Infrastructure.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IConfiguration _configuration;
    public OperationRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private NpgsqlConnection GetConn() => new(_configuration.GetConnectionString("postgres"));

    public long Create(Domain.Entities.Operation operation)
    {
        using NpgsqlConnection conn = GetConn();

        return conn.Insert(operation.ToDataModel());
    }
}
