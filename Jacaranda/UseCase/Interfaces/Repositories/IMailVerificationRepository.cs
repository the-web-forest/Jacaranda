using System;
using Models = Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface IMailVerificationRepository : IBaseRepository<Models.MailVerification>
    {
        public Models.MailVerification GetLastRegisterByToken(string Token);
    }
}

