namespace Jacaranda.Domain.Model
{
    public class PlantTag : BaseModel
    {
        public string Name { get; set; }
        public int PlantId { get; set; }

        public Plant Plant { get; set; }
    }
}


