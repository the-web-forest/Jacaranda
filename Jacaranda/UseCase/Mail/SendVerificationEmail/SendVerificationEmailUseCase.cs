﻿using System;
using Jacaranda.Domain;
using Jacaranda.Domain.Exceptions.Mail;
using Models = Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.UseCase.Interfaces.Services;

namespace Jacaranda.UseCase.Mail.SendVerificationEmail
{
    public class SendVerificationEmailUseCase : IUseCase<SendVerificationEmailUseCaseInput, SendVerificationEmailUseCaseOutput>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailVerificationRepository _mailVerificationRepository;
        private readonly IEmailService _emailService;

        public SendVerificationEmailUseCase(
               IUserRepository userRepository,
               IMailVerificationRepository mailVerificationRepository,
               IEmailService emailService
           )
        {
            _userRepository = userRepository;
            _mailVerificationRepository = mailVerificationRepository;
            _emailService = emailService;
        }

        public async Task<SendVerificationEmailUseCaseOutput> Run(SendVerificationEmailUseCaseInput Input)
        {
            var User = await _userRepository.GetByEmail(Input.Email);

            if (User is null)
                throw new InvalidEmailValidationException();

            if (User.EmailVerified is true)
                throw new InvalidEmailValidationException();

            var UserRegistrationToken = await CreateMailVerificationRegister(User);
            await SendWelcomeEmail(User.Email, User.Name, UserRegistrationToken);

            return new SendVerificationEmailUseCaseOutput();
        }


        private async Task<string> CreateMailVerificationRegister(Models.User User)
        {
            var UserRegistrationToken = Guid.NewGuid().ToString();

            await _mailVerificationRepository.Create(new Models.MailVerification
            {
                UserId = User.Id,
                Token = UserRegistrationToken
            });

            return UserRegistrationToken;
        }

        private async Task<bool> SendWelcomeEmail(string Email, string Name, string Token)
        {
            return await _emailService.SendWelcomeEmail(Email, Name, Token, Roles.User.ToString());
        }
    }
}

