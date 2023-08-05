using GerenciamentoInvestimentos.Application.Mappers;
using GerenciamentoInvestimentos.Application.Requests;
using GerenciamentoInvestimentos.Application.Responses;
using GerenciamentoInvestimentos.Domain.Interfaces.Services;

namespace GerenciamentoInvestimentos.Application.UseCases;

public class UserUseCases
{
    private readonly IUserService _userService;
    public UserUseCases(IUserService userService)
    {
        _userService = userService;
    }

    public CreateUserResponse CreateUser(CreateUserRequest request)
    {
        if (request == null) throw new ArgumentNullException("Requisição inválida");

        var user = request.ToDomain();

        if (!_userService.HasUniqueEmail(user))
            throw new Exception("Usuário já cadastrado com esse e-mail");

        var saveReturn = _userService.Save(user);

        if (saveReturn > 0)
            return user.ToResponse();
        throw new Exception("Algo deu errado na criação do usuário");
    }
}
