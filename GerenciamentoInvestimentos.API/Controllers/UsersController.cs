using GerenciamentoInvestimentos.Application.Requests;
using GerenciamentoInvestimentos.Application.UseCases;
using GerenciamentoInvestimentos.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoInvestimentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserUseCases _useCases;
        private readonly ILogger<UsersController> _logger;
        public UsersController(UserUseCases useCases, ILogger<UsersController> logger)
        {
            _useCases = useCases;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            try
            {
                _logger.LogInformation("Iniciando cadastramento de usuário");
                var response = _useCases.CreateUser(request);

                _logger.LogInformation($"Usuário cadastrado com sucesso com id: {response.Id}");
                return CreatedAtRoute(response.Id, response);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogInformation($"Erro tentar cadastrar usuário. {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro tentar cadastrar usuário. {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                _logger.LogInformation("Iniciando login");
                string token = _useCases.Login(request);

                _logger.LogInformation("Login realizado com sucesso");
                return Ok(token);
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogError($"Erro ao realizar login. {ex.Message}");
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao realizar login. {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
