using GerenciamentoInvestimentos.Application.Requests;
using GerenciamentoInvestimentos.Application.UseCases;
using GerenciamentoInvestimentos.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoInvestimentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserUseCases _useCases;
        public UsersController(UserUseCases useCases)
        {
            _useCases = useCases;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            try
            {
                var response = _useCases.CreateUser(request);
                return CreatedAtRoute(response.Id, response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                string token = _useCases.Login(request);
                return Ok(token);
            }
            catch (UnauthorizedException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
