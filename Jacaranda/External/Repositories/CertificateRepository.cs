using System;
using System.Linq;
using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.External.Repositories
{
    public class CertificateRepository : BaseRepository<Certificate>, ICertificateRepository
    {
        public CertificateRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Certificate> GetByCertificateId(string CertificateId)
        {
            return await _context.Where(x => x.CertificateId == CertificateId).FirstOrDefaultAsync();
        }
    }
}

