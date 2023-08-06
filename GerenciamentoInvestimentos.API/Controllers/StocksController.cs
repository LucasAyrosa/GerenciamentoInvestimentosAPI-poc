using GerenciamentoInvestimentos.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoInvestimentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StocksController : ControllerBase
    {
        private readonly StockUseCases _useCases;
        public StocksController(StockUseCases useCases)
        {
            _useCases = useCases;
        }

        [HttpGet("{ticket}")]
        public async Task<IActionResult> GetInformation(string ticket)
        {
            try
            {
                return Ok(await _useCases.GetStockInformation(ticket));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
