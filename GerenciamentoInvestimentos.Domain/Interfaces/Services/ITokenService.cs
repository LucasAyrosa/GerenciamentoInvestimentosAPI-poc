using GerenciamentoInvestimentos.Domain.Entities;

namespace GerenciamentoInvestimentos.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateJwtToken(User user);
}
