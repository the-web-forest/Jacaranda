using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface IBiomeRepository : IBaseRepository<Biome>
    {
        Task<bool> VerifyBiomeExistenceByName(string BiomeName);
        Task<Biome> GetBiomeByName(string Name);
        Task<List<Biome>> ListBiomes();
    }
}
