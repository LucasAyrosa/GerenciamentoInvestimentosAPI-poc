using GerenciamentoInvestimentos.Domain.Entities;

namespace GerenciamentoInvestimentos.Domain.Interfaces.Repositories;

public interface IPortifolioRepository
{
    long Create(Portifolio portifolio);
    long GetIdByFilter(long userId, string ticket, string? custody, string? wallet);
}
