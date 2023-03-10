using System;
using Jacaranda.Domain;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.States.GetCitiesByState;
using Jacaranda.UseCase.States.GetStates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers.States
{
    [ApiController]
    [Route("[controller]")]
    public class StatesController : ControllerBase
    {

        private readonly IUseCase<GetStatesUseCaseInput, GetStatesUseCaseOutput> _getStatesUseCase;
        private readonly IUseCase<GetCitiesByStateUseCaseInput, GetCitiesByStateUseCaseOutput> _getCitiesByStateUseCase;

        public StatesController(IUseCase<GetStatesUseCaseInput, GetStatesUseCaseOutput> getStatesUseCase,
            IUseCase<GetCitiesByStateUseCaseInput, GetCitiesByStateUseCaseOutput> getCitiesByStateUseCase)
        {
            _getStatesUseCase = getStatesUseCase;
            _getCitiesByStateUseCase = getCitiesByStateUseCase;
        }

        [HttpGet]
        public async Task<ObjectResult> GetStates()
        {
            try
            {
                GetStatesUseCaseOutput Data = await _getStatesUseCase.Run(new GetStatesUseCaseInput());
                return new ObjectResult(Data);
            }
            catch (BaseException e)
            {
                return new BadRequestObjectResult(e.Data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{State}/Cities")]
        public async Task<ObjectResult> GetCitiesByState(
        string State
       )
        {
            try
            {
                GetCitiesByStateUseCaseOutput Data = await _getCitiesByStateUseCase.Run(new GetCitiesByStateUseCaseInput
                {
                    State = State
                });
                return new ObjectResult(Data);
            }
            catch (BaseException e)
            {
                return new BadRequestObjectResult(e.Data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
