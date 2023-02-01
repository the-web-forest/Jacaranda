using System;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.User.Register;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUseCase<UserRegisterUseCaseInput, UserRegisterUseCaseOutput> _registerUseCase;

        public UserController(
            IUseCase<UserRegisterUseCaseInput, UserRegisterUseCaseOutput> registerUseCase
        )
        {
            _registerUseCase = registerUseCase;
        }

        [HttpPost]
        public async Task<ObjectResult> Register([FromBody] UserRegisterUseCaseInput UserRegisterInput)
        {
            try
            {
                var data = await _registerUseCase.Run(new UserRegisterUseCaseInput
                {
                    Name = UserRegisterInput.Name,
                    Email = UserRegisterInput.Email,
                    Password = UserRegisterInput.Password,
                    AllowNewsletter = UserRegisterInput.AllowNewsletter
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

