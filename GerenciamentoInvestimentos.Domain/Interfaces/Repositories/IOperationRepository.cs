using GerenciamentoInvestimentos.Domain.Entities;

namespace GerenciamentoInvestimentos.Domain.Interfaces.Repositories;

public interface IOperationRepository
{
    long Create(Operation operation);
}
