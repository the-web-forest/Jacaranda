using System;
using System.Linq;
using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.External.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<User> GetByEmail(string Email)
        {
            return await _context.Where(x => x.Email == Email).FirstOrDefaultAsync();
        }
    }
}

