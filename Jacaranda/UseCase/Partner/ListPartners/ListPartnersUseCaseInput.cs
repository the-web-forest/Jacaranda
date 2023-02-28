using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.ListPartners
{
    public class ListPartnersUseCaseInput : ListFilter
    {
        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
    }
}
