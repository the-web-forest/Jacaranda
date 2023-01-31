using System;
using Jacaranda.Context;
using Jacaranda.Controllers;
using Jacaranda.Controllers.Administrator.Dto;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.AdministratorLogin;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministratorController : ControllerBase
    {

        private readonly ILogger<AdministratorController> _logger;
        private readonly IUseCase<AdministratorLoginUseCaseInput, AdministratorLoginUseCaseOutput> _administratorLoginUseCase;

        public AdministratorController(ILogger<AdministratorController> logger, DatabaseContext databaseContext, IUseCase<AdministratorLoginUseCaseInput, AdministratorLoginUseCaseOutput> administratorLoginUseCase)
        {
            _logger = logger;
            _administratorLoginUseCase = administratorLoginUseCase;
        }

        [HttpPost("Login")]
        public async Task<ObjectResult> Login([FromBody] AdministratorLoginInput userInput)
        {
            try
            {
                _logger.LogInformation(message: "{Email} made login!", userInput.Email);
                var Data = await _administratorLoginUseCase.Run(new AdministratorLoginUseCaseInput
                {
                    Email = userInput.Email,
                    Password = userInput.Password
                });

                return new ObjectResult(Data);
            }
            catch (BaseException e)
            {
                return new BadRequestObjectResult(e.Data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}

