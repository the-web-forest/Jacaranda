namespace Jacaranda.UseCase.CreatePartners
{
    public class CreatePartnerUseCaseInput
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int TreeId { get; set; }
        public string Url { get; set; }
    }
}
