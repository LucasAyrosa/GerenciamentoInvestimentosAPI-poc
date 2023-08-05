using GerenciamentoInvestimentos.Domain.Entities;
using GerenciamentoInvestimentos.Domain.Interfaces.Repositories;
using GerenciamentoInvestimentos.Domain.Interfaces.Services;

namespace GerenciamentoInvestimentos.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool HasUniqueEmail(User user)
    {
        var userData = _userRepository.GetByEmail(user.Email);

        return userData == null;
    }

    public long Save(User user)
    {
        return _userRepository.Create(user);
    }
}
