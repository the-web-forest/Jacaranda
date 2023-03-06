using System;
using System.Security.Claims;
using Jacaranda.Controllers.User.DTOS;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.ListUsers;
using Jacaranda.UseCase.User;
using Jacaranda.UseCase.User.GetUserInfo;
using Jacaranda.UseCase.User.Login;
using Jacaranda.UseCase.User.PasswordChange;
using Jacaranda.UseCase.User.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUseCase<UserLoginUseCaseInput, UserLoginUseCaseOutput> _userLoginUseCase;
        private readonly IUseCase<UserRegisterUseCaseInput, UserRegisterUseCaseOutput> _registerUseCase;
        private readonly IUseCase<ListUsersUseCaseInput, ListUsersUseCaseOutput> _listUsersUseCase;
        private readonly IUseCase<UserDetailUseCaseInput, UserDetailUseCaseOutput> _userDetailUseCase;
        private readonly IUseCase<UserPasswordChangeUseCaseInput, UserPasswordChangeUseCaseOutput> _userPasswordChangeUseCase;
        private readonly IUseCase<GetUserInfoUseCaseInput, GetUserInfoUseCaseOutput> _getUserInfoUseCase;

        public UserController(
            IUseCase<UserRegisterUseCaseInput, UserRegisterUseCaseOutput> registerUseCase,
            IUseCase<ListUsersUseCaseInput, ListUsersUseCaseOutput> listUsersUseCase,
            IUseCase<UserDetailUseCaseInput, UserDetailUseCaseOutput> userDetailUseCase,
            IUseCase<UserPasswordChangeUseCaseInput, UserPasswordChangeUseCaseOutput> userPasswordChangeUseCase,
            IUseCase<GetUserInfoUseCaseInput, GetUserInfoUseCaseOutput> getUserInfoUseCase,
            IUseCase<UserLoginUseCaseInput, UserLoginUseCaseOutput> userLoginUseCase
        )
        {
            _registerUseCase = registerUseCase;
            _listUsersUseCase = listUsersUseCase;
            _userDetailUseCase = userDetailUseCase;
            _userPasswordChangeUseCase = userPasswordChangeUseCase;
            _getUserInfoUseCase = getUserInfoUseCase;
            _userLoginUseCase = userLoginUseCase;
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPost]
        [Route("Password/Change")]
        public async Task<ObjectResult> PasswordChange([FromBody] UserPasswordChangeInput Input)
        {
            try
            {
                var data = await _userPasswordChangeUseCase.Run(new UserPasswordChangeUseCaseInput
                {
                    Email = Input.Email,
                    Token = Input.Token,
                    Password = Input.Password
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
        [Authorize(Roles = "User")]
        public async Task<ObjectResult> GetUserInfo()
        {
            try
            {
                var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var UseCaseInput = new GetUserInfoUseCaseInput
                {
                    UserId = Convert.ToInt32(UserId)
                };
                var Data = await _getUserInfoUseCase.Run(UseCaseInput);
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
        [Route("Login")]
        public async Task<ObjectResult> Login([FromBody] UserLoginInput userInput)
        {
            try
            {
                var Data = await _userLoginUseCase.Run(new UserLoginUseCaseInput
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

