using AutoMapper;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.ListPartners
{
    public class ListPartnersUseCase : IUseCase<ListPartnersUseCaseInput, ListPartnersUseCaseOutput>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;

        public ListPartnersUseCase(
            IMapper mapper,
            IPartnerRepository partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }

        public async Task<ListPartnersUseCaseOutput> Run(ListPartnersUseCaseInput Input)
            => await _partnerRepository
                .GetPartnersByFilter(Input)
                .ContinueWith(partnersAndTotal => _mapper.Map<ListPartnersUseCaseOutput>(partnersAndTotal.Result));
    }
}
