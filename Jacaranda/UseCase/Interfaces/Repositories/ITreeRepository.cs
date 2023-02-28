using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface ITreeRepository : IBaseRepository<Tree>
    {
        Task<Tree> GetTreeById(int TreeId);
        Task<Tree> GetTreeByName(string TreeId);
        Task<List<Tree>> ListTreesPerPage(int Page, int ItensPerPage);
        Task<List<Tree>> ListActiveTreesPerPage(int Page, int ItensPerPage);
        Task<long> CountTrees();
        Task<long> CountActiveTrees();
        Task<bool> VerifyTreeExistenceById(int TreeId);
        Task<Tree> GetActiveTreeByName(string Name);
    }
}
