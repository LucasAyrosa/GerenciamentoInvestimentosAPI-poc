using GerenciamentoInvestimentos.Domain.Entities;
using GerenciamentoInvestimentos.Domain.Interfaces.Repositories;
using GerenciamentoInvestimentos.Domain.Interfaces.Services;

namespace GerenciamentoInvestimentos.Domain.Services;

public class PortifolioService : IPortifolioService
{
    private readonly IPortifolioRepository _portifolioRepository;
    public PortifolioService(IPortifolioRepository portifolioRepository)
    {
        _portifolioRepository = portifolioRepository;
    }
    public long GetIdByFilter(long userId, string ticket, string? custody, string? wallet)
    {
        return _portifolioRepository.GetIdByFilter(userId, ticket, custody, wallet);
    }

    public long Create(Portifolio portifolio) => _portifolioRepository.Create(portifolio);
}
