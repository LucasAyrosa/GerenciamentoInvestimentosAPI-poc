using GerenciamentoInvestimentos.Domain.Entities;

namespace GerenciamentoInvestimentos.Domain.Interfaces.Services;

public interface IUserService
{
    bool HasUniqueEmail(User user);
    long Save(User user);
    string UserAutentication(User loginUser);
}
