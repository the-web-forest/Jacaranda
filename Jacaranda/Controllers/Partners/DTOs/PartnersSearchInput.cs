using Jacaranda.Domain.Model;

namespace Jacaranda.Controllers.Partners.DTOs
{
    public class PartnersSearchInput : ListFilter
    {
        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
    }
}
