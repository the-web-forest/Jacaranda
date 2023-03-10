namespace Jacaranda.UseCase.States.GetCitiesByState
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetCitiesByStateUseCaseOutput
    {
        public List<City> Cities { get; set; } = new List<City>();
    }
}

