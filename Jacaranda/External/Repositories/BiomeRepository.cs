using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.External.Repositories;
public class BiomeRepository : BaseRepository<Biome>, IBiomeRepository
{
    public BiomeRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
        public async Task<bool> VerifyBiomeExistenceByName(string BiomeName)
            => await _context.CountAsync(x => x.Name.Equals(BiomeName)) > 0;

    public async Task<Biome> GetBiomeByName(string Name)
    {
        return await _context
            .Where(x => x.Name == Name && !x.Deleted)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Biome>> ListBiomes()
    {
        var Query = _context
            .Where(x => x.Name != null && !x.Deleted);

        var Results = await Query.ToListAsync();
            
        return Results;
    }

}
