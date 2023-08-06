using GerenciamentoInvestimentos.Domain.Entities;

namespace GerenciamentoInvestimentos.Domain.Interfaces.Services;

public interface IPortifolioService
{
    long Create(Portifolio portifolio);
    long GetIdByFilter(long userId, string ticket, string? custody, string? wallet);
}
