using System;
using Jacaranda.Domain.Exceptions.Mail;
using Jacaranda.Domain.Model;
using Jacaranda.Helper;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.Mail.ValidateEmail
{
    public class ValidateEmailUseCase : IUseCase<ValidateEmailUseCaseInput, ValidateEmailUseCaseOutput>
    {
        private readonly IMailVerificationRepository _mailVerificationRepository;
        private readonly IUserRepository _userRepository;

        public ValidateEmailUseCase(
            IMailVerificationRepository mailVerificationRepository,
            IUserRepository userRepository
            )
        {
            _mailVerificationRepository = mailVerificationRepository;
            _userRepository = userRepository;
        }

        public async Task<ValidateEmailUseCaseOutput> Run(ValidateEmailUseCaseInput Input)
        {
            var LastRegister = _mailVerificationRepository.GetLastRegisterByToken(Input.Token);
            ValidateMailVerificationAttempt(LastRegister, Input);
            UpdateMailVerificationRegister(LastRegister);
            await UpdateUserVerificationEmailStatus(LastRegister.UserId);
            return new ValidateEmailUseCaseOutput();

        }

        private static void ValidateMailVerificationAttempt(MailVerification MailVerification, ValidateEmailUseCaseInput Input)
        {
            if (MailVerification == null)
            {
                throw new InvalidEmailValidationException();
            }

            if (MailVerification.ActivatedAt != null)
            {
                throw new InvalidEmailValidationException();
            }

            if (MailVerification.Token != Input.Token)
            {
                throw new InvalidEmailValidationException();
            }

            DateTime Now = DateHelper.BrazilDateTimeNow();
            DateTime StartTime = MailVerification.CreatedAt;
            DateTime EndTime = StartTime.AddHours(24);

            if (Now > EndTime)
                throw new InvalidEmailValidationException();

        }

        private void UpdateMailVerificationRegister(MailVerification MailVerification)
        {
            MailVerification.ActivatedAt = DateHelper.BrazilDateTimeNow();
            _mailVerificationRepository.Update(MailVerification);
        }

        private async Task UpdateUserVerificationEmailStatus(int UserId)
        {
            var UserToUpdate = await _userRepository.GetById(UserId);
            UserToUpdate.EmailVerified = true;
            _userRepository.Update(UserToUpdate);
        }
    }
}

