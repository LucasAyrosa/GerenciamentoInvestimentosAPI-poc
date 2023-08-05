﻿using GerenciamentoInvestimentos.Application.Requests;
using GerenciamentoInvestimentos.Application.UseCases;
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
    }
}