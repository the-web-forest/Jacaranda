using Jacaranda.Domain.Exceptions;
using Jacaranda.Domain.Model;
using Jacaranda.Helper;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.DeletePartner
{
    public class DeletePartnerUseCase : IUseCase<DeletePartnerUseCaseInput, DeletePartnerUseCaseOutput>
    {
        private readonly IPartnerRepository _partnerRepository;

        public DeletePartnerUseCase(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<DeletePartnerUseCaseOutput> Run(DeletePartnerUseCaseInput Input)
        {
            var partner = await _partnerRepository.GetPartnerById(Input.Id);

            if (partner is null)
                throw new InvalidPartnerIdException();

            if (partner.Deleted)
                throw new PartnerAlreadyDeletedException();

            partner.Deleted = true;

            _partnerRepository.Update(partner);

            return new DeletePartnerUseCaseOutput();
        }
    }
}
