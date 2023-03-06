using System;
using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.External.Repositories
{
    public class PasswordResetRepository : BaseRepository<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(DatabaseContext databaseContext) : base(databaseContext)
        { }

        public PasswordReset GetByToken(string Token)
        {
            return _context.Where(x => x.Token == Token).FirstOrDefault();
        }
    }
}
