using GerenciamentoInvestimentos.Domain.Entities;
using GerenciamentoInvestimentos.Domain.Exceptions;
using GerenciamentoInvestimentos.Domain.Interfaces.Repositories;
using GerenciamentoInvestimentos.Domain.Interfaces.Services;
using GerenciamentoInvestimentos.Infrastructure.Utils;

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

    public User UserAutentication(User loginUser)
    {
        var dataUser = _userRepository.GetByEmail(loginUser.Email)
            ?? throw new UnauthorizedException("Usuário ou senha errados");

        if (dataUser.Password != loginUser.Password.CryptographyPassword())
            throw new UnauthorizedException("Usuário ou senha errados");

        return dataUser;
    }
}
