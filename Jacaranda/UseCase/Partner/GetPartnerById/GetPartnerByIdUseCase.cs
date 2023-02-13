using AutoMapper;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.GetPartnerById
{
    public class GetPartnerByIdUseCase : IUseCase<GetPartnerByIdUseCaseInput, GetPartnerByIdUseCaseOutput>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;

        public GetPartnerByIdUseCase(
            IMapper mapper, 
            IPartnerRepository partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }

        public async Task<GetPartnerByIdUseCaseOutput> Run(GetPartnerByIdUseCaseInput Input)
        {
            var partner = await _partnerRepository.GetPartnerById(Input.Id);

            if (partner is null)
                throw new InvalidPartnerIdException();

            return _mapper.Map<GetPartnerByIdUseCaseOutput>(partner);
        }
    }
}
