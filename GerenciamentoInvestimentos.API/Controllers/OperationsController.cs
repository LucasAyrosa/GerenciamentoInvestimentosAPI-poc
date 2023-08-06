using GerenciamentoInvestimentos.Application.Requests;
using GerenciamentoInvestimentos.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GerenciamentoInvestimentos.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OperationsController : ControllerBase
{
    private readonly OperationUseCases _useCases;
    private readonly ILogger<OperationsController> _logger;
    public OperationsController(OperationUseCases useCases, ILogger<OperationsController> logger)
    {
        _useCases = useCases;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Insert(InsertOperationRequest request)
    {
        try
        {
            if (!long.TryParse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value, out long userId))
            {
                _logger.LogInformation("Usuário não autenticado");
                return Unauthorized();
            }

            _logger.LogInformation("Usuário autenticado");
            var operation = (request.Type) switch
            {
                Domain.Enums.EOperationType.Buy => _useCases.InsertBuyOperation(request, userId),
                Domain.Enums.EOperationType.Sell => _useCases.InsertSellOperation(request, userId),
                _ => throw new InvalidOperationException("Tipo de operação não é válida")
            };

            _logger.LogInformation("Fim de processamento. Operação criada com sucesso");
            return CreatedAtRoute("", operation);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogInformation($"Erro no processamento. {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Erro no processamento. {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }
}
