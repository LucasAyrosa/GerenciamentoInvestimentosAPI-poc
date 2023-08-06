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
    public OperationsController(OperationUseCases useCases)
    {
        _useCases = useCases;
    }

    [HttpPost]
    public IActionResult Insert(InsertOperationRequest request)
    {
        try
        {
            if (!long.TryParse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value, out long userId))
                return Unauthorized();

            var operation = (request.Type) switch
            {
                Domain.Enums.EOperationType.Buy => _useCases.InsertBuyOperation(request, userId),
                Domain.Enums.EOperationType.Sell => _useCases.InsertSellOperation(request, userId),
                _ => throw new InvalidOperationException("Tipo de operação não é válida")
            };

            return CreatedAtRoute("", operation);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
