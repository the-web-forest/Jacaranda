using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.External.Repositories;
public class TreeRepository : BaseRepository<Tree>, ITreeRepository
{
    public TreeRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<long> CountTrees()
    {
        var Query = _context.Where(x => x.Name != null);
        var TotalTask = await Query.CountAsync();
        return TotalTask;
    }

    public async Task<long> CountActiveTrees()
    {
        var Query = _context.Where(x => x.Name != null && !x.Deleted);
        var TotalTask = await Query.CountAsync();
        return TotalTask;
    }

        public async Task<bool> VerifyTreeExistenceById(int TreeId)
            => await _context.CountAsync(x => x.Id.Equals(TreeId)) > 0;

        public async Task<Tree> GetTreeById(int TreeId)
            => await _context.Where(x => x.Id == TreeId).FirstOrDefaultAsync();

    public async Task<Tree> GetTreeByName(string Name)
    {
        return await _context
            .Where(x => x.Name == Name && !x.Deleted)
            .FirstOrDefaultAsync();
    }

    public async Task<Tree> GetActiveTreeByName(string Name)
    {
        return await _context
            .Where(x => x.Name == Name && !x.Deleted)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Tree>> ListTreesPerPage(int Page, int ItensPerPage)
    {
        var SkipQuantity = (Page == 1) 
            ? 0 
            : ((Page - 1) * ItensPerPage);

        var Query = _context
            .Where(x => x.Name != null);

        var Results = await Query
            .Skip(SkipQuantity)
            .Take(ItensPerPage)
            .ToListAsync();
            
        return Results;
    }

    public async Task<List<Tree>> ListActiveTreesPerPage(int Page, int ItensPerPage)
    {
        var SkipQuantity = (Page == 1) ? 0 : ((Page - 1) * ItensPerPage);

        var Query = _context
            .Where(x => x.Name != null && !x.Deleted);

        var Results = await Query
            .Skip(SkipQuantity)
            .Take(ItensPerPage)
            .ToListAsync();

        return Results;
    }

}
