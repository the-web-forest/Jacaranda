namespace Jacaranda.Domain.Model
{
    public class Tree : BaseModel
    {
        public string Name { get; set; }
        public int BiomeId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Value { get; set; }

        public Biome Biome { get; set; }
        public ICollection<Partner> Partners { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}


