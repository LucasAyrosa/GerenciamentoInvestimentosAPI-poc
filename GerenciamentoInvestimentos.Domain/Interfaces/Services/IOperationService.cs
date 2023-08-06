using GerenciamentoInvestimentos.Domain.Entities;

namespace GerenciamentoInvestimentos.Domain.Interfaces.Services;

public interface IOperationService
{
    long Create(Operation operation);
}
