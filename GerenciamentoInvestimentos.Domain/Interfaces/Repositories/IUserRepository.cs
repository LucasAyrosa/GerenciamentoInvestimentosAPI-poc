using GerenciamentoInvestimentos.Domain.Entities;

namespace GerenciamentoInvestimentos.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    long Create(User user);
    IEnumerable<User> Get();
    User Get(long id);
    User GetByEmail(string email);
}
