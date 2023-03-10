using Jacaranda.Domain.Exceptions.State;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.States.GetCitiesByState
{
    public class GetCitiesByStateUseCase : IUseCase<GetCitiesByStateUseCaseInput, GetCitiesByStateUseCaseOutput>
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;

        public GetCitiesByStateUseCase(IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        public Task<GetCitiesByStateUseCaseOutput> Run(GetCitiesByStateUseCaseInput Input)
        {
            var State = _stateRepository.FindStateByInitial(Input.State) ?? throw new InvalidStateException();
            var CitiesList = _cityRepository.FindCitiesByStateId(State.Id);

            var Output = new GetCitiesByStateUseCaseOutput();

            CitiesList.ForEach(x =>
            {
                Output.Cities.Add(new City
                {
                    Id = x.Id,
                    Name = x.Name
                });
            });

            return Task.FromResult(Output);
        }
    }
}

