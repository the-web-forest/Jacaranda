﻿using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.States.GetStates
{
    public class GetStatesUseCase : IUseCase<GetStatesUseCaseInput, GetStatesUseCaseOutput>
    {

        private readonly IStateRepository _stateRepository;

        public GetStatesUseCase(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public Task<GetStatesUseCaseOutput> Run(GetStatesUseCaseInput Input)
        {
            var States = _stateRepository.FindAll();
            var Output = new GetStatesUseCaseOutput();

            foreach (var State in States)
            {
                var Data = new StateOutput
                {
                    Id = State.Id,
                    Name = State.Name,
                    Initial = State.Initials
                };
                Output.States.Add(Data);
            }

            Output.States.Sort((X, Y) => string.Compare(X.Initial, Y.Initial));
            return Task.FromResult(Output);
        }
    }
}

