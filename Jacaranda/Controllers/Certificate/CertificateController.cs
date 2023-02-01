using System;
using Jacaranda.Context;
using Jacaranda.Controllers;
using Jacaranda.Controllers.Administrator.Dto;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.AdministratorLogin;
using Jacaranda.UseCase.Certificate.GetCertificateByIdUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificateController : ControllerBase
    {

        private readonly ILogger<CertificateController> _logger;
        private readonly IUseCase<GetCertificateByIdUseCaseInput, GetCertificateByIdUseCaseOutput> _getCertificateByIdUseCase;

        public CertificateController(ILogger<CertificateController> logger, DatabaseContext databaseContext, IUseCase<GetCertificateByIdUseCaseInput, GetCertificateByIdUseCaseOutput> getCertificateByIdUseCase)
        {
            _logger = logger;
            _getCertificateByIdUseCase = getCertificateByIdUseCase;
        }

        [HttpGet]
        public async Task<ObjectResult> GetCertificateById([FromQuery] string CertificateId)
        {
            try
            {
                _logger.LogInformation(message: "{CertificateId} made login!", CertificateId);

                var Data = await _getCertificateByIdUseCase.Run(new GetCertificateByIdUseCaseInput
                {
                    CertificateId = CertificateId
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

