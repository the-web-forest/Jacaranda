using System;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.Configuration.GetPublicConfigurationUseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers.Configuration
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {

        private readonly ILogger<ConfigurationController> _logger;
        private readonly IUseCase<GetPublicConfigurationUseCaseInput, GetPublicConfigurationUseCaseOutput> _configurationUseCase;

        public ConfigurationController(ILogger<ConfigurationController> logger, IUseCase<GetPublicConfigurationUseCaseInput, GetPublicConfigurationUseCaseOutput> configurationUseCase)
        {
            _logger = logger;
            _configurationUseCase = configurationUseCase;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ObjectResult> PaymentPublicKey()
        {
            _logger.LogInformation("Configuration Requested");

            try
            {
                var Data = await _configurationUseCase
                    .Run(new GetPublicConfigurationUseCaseInput());

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

