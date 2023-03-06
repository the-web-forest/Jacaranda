using System;
using Jacaranda.Controllers.Mail.Inputs;
using Jacaranda.Domain;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.Mail.CheckEmailUseCase;
using Jacaranda.UseCase.Mail.SendVerificationEmail;
using Jacaranda.UseCase.Mail.UserPasswordResetUseCase;
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
        private readonly IUseCase<CheckEmailUseCaseInput, CheckEmailUseCaseOutput> _checkEmailUseCase;
        private readonly IUseCase<UserPasswordResetUseCaseInput, UserPasswordResetUseCaseOutput> _userPasswordResetUseCase;

        public MailController(
            IUseCase<ValidateEmailUseCaseInput, ValidateEmailUseCaseOutput> validateEmailUseCase,
            IUseCase<SendVerificationEmailUseCaseInput, SendVerificationEmailUseCaseOutput> sendVerificationEmailUseCase,
            IUseCase<CheckEmailUseCaseInput, CheckEmailUseCaseOutput> checkEmailUseCase,
            IUseCase<UserPasswordResetUseCaseInput, UserPasswordResetUseCaseOutput> userPasswordResetUseCase
        )

        {
            _validateEmailUseCase = validateEmailUseCase;
            _sendVerificationEmailUseCase = sendVerificationEmailUseCase;
            _checkEmailUseCase = checkEmailUseCase;
            _userPasswordResetUseCase = userPasswordResetUseCase;
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

        [HttpGet]
        [Route("Check")]
        public async Task<ObjectResult> Check(
        [FromQuery(Name = "email")] string Email)
        {
            try
            {
                var Data = await _checkEmailUseCase.Run(new CheckEmailUseCaseInput
                {
                    Email = Email
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
        [Route("Send/PasswordReset")]
        public async Task<ObjectResult> PasswordReset([FromBody] UserPasswordResetInput Input)
        {
            try
            {
                var data = await _userPasswordResetUseCase.Run(new UserPasswordResetUseCaseInput
                {
                    Email = Input.Email
                });

                return new OkObjectResult(data);
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

