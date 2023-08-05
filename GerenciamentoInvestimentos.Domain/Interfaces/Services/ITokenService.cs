namespace GerenciamentoInvestimentos.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateJwtToken(string username);
}
