using System;
using Jacaranda.Domain.Exceptions.Mail;
using Models = Jacaranda.Domain.Model;
using Jacaranda.Helper;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.UseCase.Interfaces.Services;
using BCryptLib = BCrypt.Net.BCrypt;
using Jacaranda.Domain.Exceptions.User;

namespace Jacaranda.UseCase.User.PasswordChange
{
    public class UserPasswordChangeUseCase : IUseCase<UserPasswordChangeUseCaseInput, UserPasswordChangeUseCaseOutput>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordResetRepository _passwordResetRepository;
        private readonly IEmailService _emailService;

        public UserPasswordChangeUseCase(
            IUserRepository userRepository,
            IEmailService emailService,
            IPasswordResetRepository passwordResetRepository
        )
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _passwordResetRepository = passwordResetRepository;
        }

        public async Task<UserPasswordChangeUseCaseOutput> Run(UserPasswordChangeUseCaseInput Input)
        {
            var User = await _userRepository.GetByEmail(Input.Email);

            if (User is null)
                throw new InvalidEmailException();

            var LastRegister = _passwordResetRepository.GetByToken(Input.Token);
            ValidateMailPasswordResetAttempt(LastRegister, Input);
            UpdatePasswordResetRegister(LastRegister);
            UpdateUserPasssowrd(User, Input);

            return new UserPasswordChangeUseCaseOutput { Changed = true };
        }

        private static void ValidateMailPasswordResetAttempt(Models.PasswordReset PasswordReset, UserPasswordChangeUseCaseInput Input)
        {
            if (PasswordReset == null)
                throw new InvalidPasswordResetException();

            if (PasswordReset.ActivatedAt != null)
                throw new InvalidPasswordResetException();

            DateTime Now = DateHelper.BrazilDateTimeNow();
            DateTime StartTime = PasswordReset.CreatedAt;
            DateTime EndTime = StartTime.AddHours(24);

            if (Now > EndTime)
                throw new InvalidPasswordResetException();

        }

        private void UpdatePasswordResetRegister(Models.PasswordReset PasswordReset)
        {
            PasswordReset.ActivatedAt = DateHelper.BrazilDateTimeNow();
            _passwordResetRepository.Update(PasswordReset);
        }

        private void UpdateUserPasssowrd(Models.User User, UserPasswordChangeUseCaseInput Input)
        {
            User.Password = BCryptLib.HashPassword(Input.Password);
            _userRepository.Update(User);
        }
    }

}

