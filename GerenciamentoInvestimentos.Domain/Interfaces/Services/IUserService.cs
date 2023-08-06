using GerenciamentoInvestimentos.Domain.Entities;

namespace GerenciamentoInvestimentos.Domain.Interfaces.Services;

public interface IUserService
{
    User GetUser(long id);
    bool HasUniqueEmail(User user);
    long Save(User user);
    User UserAutentication(User loginUser);
}
