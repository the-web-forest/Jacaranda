using Jacaranda.Domain.Model;
using Jacaranda.UseCase.ListPartners;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.Context;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.External.Repositories
{
    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(DatabaseContext databaseContext) : base(databaseContext)
        { }

        public async Task<Paging<Partner>> GetPartnersByFilter(ListPartnersUseCaseInput filter)
        {
            var query = _context.AsQueryable();

            if (!String.IsNullOrEmpty(filter.Name))
                query = query
                    .Where(partner => !String.IsNullOrEmpty(partner.Name) && partner.Name.ToLower().Contains(filter.Name.Trim().ToLower()));

            if (!String.IsNullOrEmpty(filter.Email))
                query = query
                    .Where(partner => !String.IsNullOrEmpty(partner.Email) && partner.Email.ToLower().Contains(filter.Email.Trim().ToLower()));

            if (!String.IsNullOrEmpty(filter.Url))
                query = query
                    .Where(partner => !String.IsNullOrEmpty(partner.Url) && partner.Url.ToLower().Contains(filter.Url.Trim().ToLower()));

            if (filter.Code is not null && filter.Code > 0)
                query = query
                    .Where(partner => partner.Code == filter.Code);

            query = query.Where(partner => !partner.Deleted);

            query = query
                .OrderBy(partner => partner.CreatedAt);

            long? total = null;
            if (filter.RequiredTotal == true)
                total = query.Count();

            if (filter.Skip is not null)
                query = query
                    .Skip(filter.Skip ?? 0);

            if (filter.Take is not null)
                query = query
                    .Take(filter.Take ?? 0);

            return await query
                .ToListAsync()
                .ContinueWith(partners => new Paging<Partner>
                {
                    Data = partners.Result,
                    TotalCount = total
                });
        }

        public async Task<Partner?> GetPartnerById(int id)
            => await _context.AsQueryable().Where(partner => partner.Id == id).FirstOrDefaultAsync();

        public async Task<bool> VerifyPartnerEmailExistence(string email)
            => await _context.CountAsync(x => x.Email.Equals(email)) > 0;

        public async Task<int> GetNextCode()
            => await _context
                .OrderByDescending(partner => partner.Code)
                .FirstAsync()
                .ContinueWith(partner => partner.Result.Code + 1);

        public async Task<Partner?> GetPartnerByEmail(string email)
            => await _context.AsQueryable().Where(partner => partner.Email == email).FirstOrDefaultAsync();

    }
}
