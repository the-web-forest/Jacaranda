using System;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase.Interfaces.Repositories;
using Models = Jacaranda.Domain.Model;
using BCryptLib = BCrypt.Net.BCrypt;
using Jacaranda.Domain;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Services;

namespace Jacaranda.UseCase.User.Register
{
    public class UserRegisterUseCase : IUseCase<UserRegisterUseCaseInput, UserRegisterUseCaseOutput>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMailVerificationRepository _mailVerificationRepository;
        private readonly IEmailService _emailService;

        public UserRegisterUseCase(
            IUserRepository userRepository,
            IMailVerificationRepository mailVerificationRepository,
            IEmailService emailService
            )
        {
            _userRepository = userRepository;
            _mailVerificationRepository = mailVerificationRepository;
            _emailService = emailService;
        }

        public async Task<UserRegisterUseCaseOutput> Run(UserRegisterUseCaseInput Input)
        {
            await VerifyIfUserIsAlreadyRegistered(Input.Email);
            await CreateUser(Input);
            var UserCreated = await _userRepository.GetByEmail(Input.Email);
            var UserRegistrationToken = await CreateMailVerificationRegister(UserCreated);
            await SendWelcomeEmail(Input.Email, Input.Name, UserRegistrationToken);
            await RecoveryTrees(Input.Email);
            return new UserRegisterUseCaseOutput();
        }

        private async Task CreateUser(UserRegisterUseCaseInput Input)
        {
            await _userRepository.Create(new Models.User
            {
                Email = Input.Email,
                Name = Input.Name,
                Password = BCryptLib.HashPassword(Input.Password),
                EmailVerified = false,
                Origin = Origins.WebForest.ToString(),
                AllowNewsletter = Input.AllowNewsletter
            });
        }

        private async Task VerifyIfUserIsAlreadyRegistered(string Email)
        {
            var UserAlreadyExists = await _userRepository.GetByEmail(Email);

            if (UserAlreadyExists != null)
                throw new EmailAlreadyRegisteredException();
        }

        private async Task<string> CreateMailVerificationRegister(Models.User User)
        {
            var UserRegistrationToken = Guid.NewGuid().ToString();

            await _mailVerificationRepository.Create(new MailVerification
            {
                Token = UserRegistrationToken,
                UserId = User.Id
            });

            return UserRegistrationToken;
        }

        private async Task<bool> SendWelcomeEmail(string Email, string Name, string Token)
        {
            return await _emailService.SendWelcomeEmail(Email, Name, Token, Roles.User.ToString());
        }

        private async Task RecoveryTrees(string UserEmail)
        {
            var User = await _userRepository.GetByEmail(UserEmail);
            // await _plantRepository.RecoveryPlants(User.Id, User.Email);
        }
    }
}

