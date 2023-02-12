using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.UpdateTree
{
    public class UpdateTreeUseCaseInput 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public Biome Biome { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
