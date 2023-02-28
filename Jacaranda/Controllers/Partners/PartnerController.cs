using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Jacaranda.Controllers.Partners.DTOs;
using AutoMapper;
using Jacaranda.UseCase;
using Jacaranda.UseCase.ListPartners;
using Jacaranda.UseCase.CreatePartners;
using Jacaranda.UseCase.UpdatePartner;
using Jacaranda.UseCase.GetPartnerById;
using Jacaranda.UseCase.DeletePartner;
using Jacaranda.Domain.Exceptions;

namespace Jacaranda.Controllers.Partners
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class PartnerController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PartnerController> _logger;
        private readonly IUseCase<ListPartnersUseCaseInput, ListPartnersUseCaseOutput> _listPartnersUseCase;
        private readonly IUseCase<CreatePartnerUseCaseInput, CreatePartnerUseCaseOutput> _createPartnerUseCase;
        private readonly IUseCase<UpdatePartnerUseCaseInput, UpdatePartnerUseCaseOutput> _updatePartnerUseCase;
        private readonly IUseCase<GetPartnerByIdUseCaseInput, GetPartnerByIdUseCaseOutput> _getPartnerByIdUseCase;
        private readonly IUseCase<DeletePartnerUseCaseInput, DeletePartnerUseCaseOutput> _deletePartnerUseCase;

        public PartnerController(
            IMapper mapper,
            ILogger<PartnerController> logger,
            IUseCase<ListPartnersUseCaseInput, ListPartnersUseCaseOutput> listPartnersUseCase,
            IUseCase<CreatePartnerUseCaseInput, CreatePartnerUseCaseOutput> createPartnerUseCase,
            IUseCase<UpdatePartnerUseCaseInput, UpdatePartnerUseCaseOutput> updatePartnerUseCase,
            IUseCase<GetPartnerByIdUseCaseInput, GetPartnerByIdUseCaseOutput> getPartnerByIdUseCase,
            IUseCase<DeletePartnerUseCaseInput, DeletePartnerUseCaseOutput> deletePartnerUseCase
            )
		{
            _mapper = mapper;
            _listPartnersUseCase = listPartnersUseCase;
            _createPartnerUseCase = createPartnerUseCase;
            _updatePartnerUseCase = updatePartnerUseCase;
            _getPartnerByIdUseCase = getPartnerByIdUseCase;
            _deletePartnerUseCase = deletePartnerUseCase;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ObjectResult> CreatePartner([FromBody] CreatePartnerInput input)
        {
            _logger.LogInformation("Create partner has called => {Name}", input.Name);

            try
            {
                var data = await _createPartnerUseCase.Run(_mapper.Map<CreatePartnerUseCaseInput>(input));

                return new ObjectResult(data);
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

        [HttpPut]
        public async Task<ObjectResult> UpdatePartner([FromBody] UpdatePartnerInput input)
        {
            _logger.LogInformation("Update partner has called => {Id}", input.Id);

            try
            {
                var data = await _updatePartnerUseCase.Run(_mapper.Map<UpdatePartnerUseCaseInput>(input));

                return new ObjectResult(data);
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

        [HttpGet("List")]
        public async Task<ObjectResult> GetPartners([FromQuery] PartnersSearchInput input)
        {
            _logger.LogInformation("Get partner list has called");

            try
            {
                var data = await _listPartnersUseCase.Run(_mapper.Map<ListPartnersUseCaseInput>(input));

                return new ObjectResult(data);
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

        [HttpGet("{Id}")]
        public async Task<ObjectResult> GetPartnerById(int Id)
        {
            _logger.LogInformation("Get partner by identificator has called => {Id}", Id);
            try
            {
                var data = await _getPartnerByIdUseCase.Run(new GetPartnerByIdUseCaseInput
                {
                    Id = Id
                });

                return new ObjectResult(data);
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

        [HttpDelete("{Id}")]
        public async Task<ObjectResult> DeletePartner(int Id)
        {
            _logger.LogInformation("Delete partner has called => {Id}", Id);

            try
            {
                var data = await _deletePartnerUseCase.Run(new DeletePartnerUseCaseInput
                {
                    Id = Id
                });

                return new ObjectResult(data);
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

