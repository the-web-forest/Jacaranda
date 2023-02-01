namespace Jacaranda.Domain.Model
{
    public class Plant : BaseModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public double Value { get; set; }

        public int UserId { get; set; }
        public int TreeId { get; set; }
        public int PartnerId { get; set; }

        public User User { get; set; }
        public Tree Tree { get; set; }
        public Partner Partner { get; set; }
        public Order Order { get; set; }
        public ICollection<PlantTag> Tags { get; set; }
    }
}


