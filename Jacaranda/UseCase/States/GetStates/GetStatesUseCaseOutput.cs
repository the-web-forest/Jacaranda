using System;
namespace Jacaranda.UseCase.States.GetStates
{
    public class StateOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initial { get; set; }
    }

    public class GetStatesUseCaseOutput
    {
        public List<StateOutput> States { get; set; } = new List<StateOutput>();
    }
}

