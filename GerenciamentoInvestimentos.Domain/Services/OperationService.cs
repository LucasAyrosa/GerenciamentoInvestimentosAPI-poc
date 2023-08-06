using GerenciamentoInvestimentos.Domain.Entities;
using GerenciamentoInvestimentos.Domain.Interfaces.Repositories;
using GerenciamentoInvestimentos.Domain.Interfaces.Services;

namespace GerenciamentoInvestimentos.Domain.Services;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _operationRepository;
    public OperationService(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository;
    }

    public long Create(Operation operation) => _operationRepository.Create(operation);
}
