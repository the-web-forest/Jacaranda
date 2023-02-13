using Jacaranda.UseCase.ListPartners.DTOs;

namespace Jacaranda.UseCase.ListPartners
{
    public class ListPartnersUseCaseOutput
    {
        public IEnumerable<LightPartner> Partners { get; set; }
        public long? TotalCount { get; set; }
    }
}
