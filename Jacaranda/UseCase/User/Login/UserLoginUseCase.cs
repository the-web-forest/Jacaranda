using System;
using Jacaranda.Domain;
using Jacaranda.Domain.Exceptions;
using Jacaranda.Domain.Exceptions.Mail;
using Jacaranda.UseCase.Interfaces;
using Jacaranda.UseCase.Interfaces.Repositories;
using BCryptLib = BCrypt.Net.BCrypt;
using Models = Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.User.Login
{
    public class UserLoginUseCase : IUseCase<UserLoginUseCaseInput, UserLoginUseCaseOutput>
    {

        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public UserLoginUseCase(
            IAuthService authService,
            IUserRepository userRepository
        )
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<UserLoginUseCaseOutput> Run(UserLoginUseCaseInput Input)
        {
            var User = await _userRepository.GetByEmail(Input.Email);

            ValidateUser(User);

            var passwordIsValid = BCryptLib.Verify(Input.Password, User.Password);

            if (passwordIsValid is false)
                throw new InvalidPasswordException();

            return BuildResponse(User);
        }

        private static void ValidateUser(Models.User User)
        {
            if (User is null)
                throw new InvalidPasswordException();

            if (User.EmailVerified is false)
                throw new UnverifiedEmailException();
        }

        private UserLoginUseCaseOutput BuildResponse(Models.User User)
        {
            return new UserLoginUseCaseOutput
            {
                AccessToken = _authService.GenerateToken(User),
                TokenType = "Bearer",
                User = new OutputUser
                {
                    Id = User.Id,
                    Email = User.Email,
                    Name = User.Name,
                    Photo = User.Photo
                }
            };
        }
    }
}

