using System;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.ListUsers;
using Jacaranda.UseCase.User;
using Jacaranda.UseCase.User.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUseCase<UserRegisterUseCaseInput, UserRegisterUseCaseOutput> _registerUseCase;
        private readonly IUseCase<ListUsersUseCaseInput, ListUsersUseCaseOutput> _listUsersUseCase;
        private readonly IUseCase<UserDetailUseCaseInput, UserDetailUseCaseOutput> _userDetailUseCase;

        public UserController(
            IUseCase<UserRegisterUseCaseInput, UserRegisterUseCaseOutput> registerUseCase,
            IUseCase<ListUsersUseCaseInput, ListUsersUseCaseOutput> listUsersUseCase,
            IUseCase<UserDetailUseCaseInput, UserDetailUseCaseOutput> userDetailUseCase
        )
        {
            _registerUseCase = registerUseCase;
            _listUsersUseCase = listUsersUseCase;
            _userDetailUseCase = userDetailUseCase;
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

        [HttpGet]
        [Route("List")]
        [Authorize]
        public async Task<ObjectResult> List([FromQuery(Name = "Page")] int Page)
        {

            if (Page < 1)
            {
                Page = 1;
            }

            try
            {
                var Data = await _listUsersUseCase.Run(new ListUsersUseCaseInput
                {
                    Page = Page
                });
                return new ObjectResult(Data);
            }
            catch (BaseException e)
            {
                return new BadRequestObjectResult(e.Data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet]
        [Route("{UserId}")]
        [Authorize]
        public async Task<ObjectResult> UserDetails(int UserId)
        {
            try
            {
                var Data = await _userDetailUseCase.Run(new UserDetailUseCaseInput
                {
                    Id = UserId
                });
                return new ObjectResult(Data);
            }
            catch (BaseException e)
            {
                return new BadRequestObjectResult(e.Data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}

