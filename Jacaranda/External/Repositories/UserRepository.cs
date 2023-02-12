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

        public async Task<long> CountUsers()
        {
            var Query = _context.Where(x => x.Name != null);
            var TotalTask = await Query.CountAsync();
            return TotalTask;
        }

        public async Task<User> GetById(int UserId)
        {
            return await _context.Where(x => x.Id == UserId).FirstOrDefaultAsync();
        }

        public async Task<List<User>> ListUsersPerPage(int Page, int ItensPerPage)
        {
            var SkipQuantity = (Page == 1) ? 0 : ((Page - 1) * ItensPerPage);
            var Query = _context.Where(x => x.Name != null);
            var Results = await Query.Skip(SkipQuantity).Take(ItensPerPage).ToListAsync();
            return Results;
        }
    }
}

