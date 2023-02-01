namespace Jacaranda.Domain.Model
{
    public class Partner : BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }

        public int TreeId { get; set; }

        public Tree Tree { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}


