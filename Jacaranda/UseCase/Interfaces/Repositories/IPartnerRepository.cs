using Jacaranda.Domain.Model;
using Jacaranda.UseCase.ListPartners;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface IPartnerRepository : IBaseRepository<Partner>
    {
        Task<Paging<Partner>> GetPartnersByFilter(ListPartnersUseCaseInput filter);
        Task<bool> VerifyPartnerEmailExistence(string email);
        Task<int> GetNextCode();
        Task<Partner?> GetPartnerById(int id);
        Task<Partner?> GetPartnerByEmail(string email);
    }
}
