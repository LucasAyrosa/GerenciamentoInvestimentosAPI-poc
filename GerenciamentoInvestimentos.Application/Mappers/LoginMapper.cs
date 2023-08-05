using GerenciamentoInvestimentos.Application.Requests;

namespace GerenciamentoInvestimentos.Application.Mappers;

public static class LoginMapper
{
    public static Domain.Entities.User ToDomainUser(this LoginRequest request)
        => new(0, string.Empty, request.Email, request.Password);
}
