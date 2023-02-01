using System;
using System.Linq;
using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.External.Repositories
{
    public class AdministratorRepository : BaseRepository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Administrator> GetByEmail(string Email)
        {
            return await _context.Where(x => x.Email == Email).FirstOrDefaultAsync();
        }
    }
}

