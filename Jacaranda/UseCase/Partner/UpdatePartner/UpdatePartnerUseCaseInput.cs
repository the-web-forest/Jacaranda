namespace Jacaranda.UseCase.UpdatePartner
{
    public class UpdatePartnerUseCaseInput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int? TreeId { get; set; }
        public string? Url { get; set; }
    }
}
