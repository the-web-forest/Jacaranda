
using System;
using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface IPasswordResetRepository : IBaseRepository<PasswordReset>
    {
        PasswordReset GetByToken(string Token);
    }
}

