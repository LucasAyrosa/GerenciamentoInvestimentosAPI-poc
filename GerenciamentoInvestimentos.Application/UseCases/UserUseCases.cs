using GerenciamentoInvestimentos.Application.Mappers;
using GerenciamentoInvestimentos.Application.Requests;
using GerenciamentoInvestimentos.Application.Responses;
using GerenciamentoInvestimentos.Domain.Entities;
using GerenciamentoInvestimentos.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace GerenciamentoInvestimentos.Application.UseCases;

public class UserUseCases
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly ILogger<UserUseCases> _logger;
    public UserUseCases(IUserService userService, ITokenService tokenService, ILogger<UserUseCases> logger)
    {
        _userService = userService;
        _tokenService = tokenService;
        _logger = logger;
    }

    public CreateUserResponse CreateUser(CreateUserRequest request)
    {
        if (request == null) throw new ArgumentNullException("Requisição inválida");

        var user = request.ToDomain();

        _logger.LogInformation("Verificando se há algum usuário utilizando o e-mail digitado");
        if (!_userService.HasUniqueEmail(user))
            throw new Exception("Usuário já cadastrado com esse e-mail");

        _logger.LogInformation("Cadastrando novo usuário");
        var saveReturn = _userService.Save(user);

        if (saveReturn > 0)
            return user.ToResponse();
        throw new Exception("Algo deu errado na criação do usuário");
    }

    public string Login(LoginRequest request)
    {
        if (request == null) throw new ArgumentNullException("Requisição inválida");

        User user = _userService.UserAutentication(request.ToDomainUser());

        return _tokenService.GenerateJwtToken(user);
    }
}
