using System;
using Jacaranda.Domain;
using Jacaranda.Domain.Exceptions.Mail;
using Models = Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.UseCase.Interfaces.Services;

namespace Jacaranda.UseCase.Mail.UserPasswordResetUseCase
{
    public class UserPasswordResetUseCase : IUseCase<UserPasswordResetUseCaseInput, UserPasswordResetUseCaseOutput>
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordResetRepository _passwordResetRepository;
        private readonly IEmailService _emailService;

        public UserPasswordResetUseCase(
            IUserRepository userRepository,
            IEmailService emailService,
            IPasswordResetRepository passwordResetRepository
        )
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _passwordResetRepository = passwordResetRepository;
        }

        public async Task<UserPasswordResetUseCaseOutput> Run(UserPasswordResetUseCaseInput Input)
        {
            var User = await _userRepository.GetByEmail(Input.Email);

            if (User is null)
            {
                throw new InvalidEmailException();
            }

            if (User.EmailVerified is false)
            {
                throw new UnverifiedEmailException();
            }

            var PasswordResetToken = await CreateMailPasswordResetRegisterAsync(User);

            await SendPasswordResetEmail(Input.Email, User.Name, PasswordResetToken);

            return new UserPasswordResetUseCaseOutput
            {
                Send = true
            };
        }

        private async Task<string> CreateMailPasswordResetRegisterAsync(Models.User User)
        {
            var UserPasswordReset = Guid.NewGuid().ToString();

            await _passwordResetRepository.Create(new Models.PasswordReset
            {
                UserId = User.Id,
                Token = UserPasswordReset
            });

            return UserPasswordReset;
        }

        private async Task<bool> SendPasswordResetEmail(string Email, string Name, string Token)
        {
            return await _emailService.SendPasswordResetEmail(Email, Name, Token, Roles.User.ToString());
        }

    }
}

