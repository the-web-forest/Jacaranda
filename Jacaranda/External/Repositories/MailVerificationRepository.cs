using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.External.Repositories;
public class MailVerificationRepository : BaseRepository<MailVerification>, IMailVerificationRepository
{
    public MailVerificationRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }

    public MailVerification GetLastRegisterByToken(string Token)
    {
        return _context.Where(x => x.Token == Token).OrderByDescending(x => x.Id).FirstOrDefault();
    }
}
