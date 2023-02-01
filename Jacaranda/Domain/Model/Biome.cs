namespace Jacaranda.Domain.Model
{
    public class Biome : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Tree> Trees { get; set; }
    }
}


