using System;
using Jacaranda.Domain;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.Mail.SendVerificationEmail;
using Jacaranda.UseCase.Mail.ValidateEmail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers.Mail
{

    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IUseCase<ValidateEmailUseCaseInput, ValidateEmailUseCaseOutput> _validateEmailUseCase;
        private readonly IUseCase<SendVerificationEmailUseCaseInput, SendVerificationEmailUseCaseOutput> _sendVerificationEmailUseCase;

        public MailController(
            IUseCase<ValidateEmailUseCaseInput, ValidateEmailUseCaseOutput> validateEmailUseCase,
            IUseCase<SendVerificationEmailUseCaseInput, SendVerificationEmailUseCaseOutput> sendVerificationEmailUseCase)
        {
            _validateEmailUseCase = validateEmailUseCase;
            _sendVerificationEmailUseCase = sendVerificationEmailUseCase;
        }

        [HttpPost]
        [Route("Validate")]
        public async Task<ObjectResult> Validate([FromBody] ValidateEmailInput Input)
        {

            try
            {
                var Data = await _validateEmailUseCase.Run(new ValidateEmailUseCaseInput
                {
                    Token = Input.Token
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

        [HttpPost]
        [Route("Send/Validation")]
        public async Task<ObjectResult> Validate([FromBody] SendEmailInput Input)
        {
            try
            {
                var Data = await _sendVerificationEmailUseCase.Run(new SendVerificationEmailUseCaseInput
                {
                    Email = Input.Email
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

