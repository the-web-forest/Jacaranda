using AutoMapper;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.Util;

namespace Jacaranda.UseCase.UpdatePartner
{
    public class UpdatePartnerUseCase : IUseCase<UpdatePartnerUseCaseInput, UpdatePartnerUseCaseOutput>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;
        private readonly ITreeRepository _treeRepository;

        public UpdatePartnerUseCase(
            IMapper mapper,
            IPartnerRepository partnerRepository,
            ITreeRepository treeRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
            _treeRepository = treeRepository;
        }

        public async Task<UpdatePartnerUseCaseOutput> Run(UpdatePartnerUseCaseInput input)
        {
            var partner = await _partnerRepository.GetPartnerById(input.Id);
            if (partner is null)
                throw new InvalidPartnerIdException();

            if (!string.IsNullOrEmpty(input.Email) &&
                !RegexUtilities.IsValidEmailAdress(input.Email))
                    throw new InvalidPartnerEmailException();

            if (!string.IsNullOrEmpty(input.Url) &&
                !RegexUtilities.IsValidUrl(input.Url))
                    throw new InvalidPartnerUrlException();

            if (!string.IsNullOrEmpty(input.Password) && 
                !RegexUtilities.IsValidPassword(input.Password))
                throw new InvalidPartnerPasswordException();

            if (!string.IsNullOrEmpty(input.Email) && 
                await VerifyEmailExists(input.Email, input.Id))
                throw new EmailAlreadyRegisteredException();

            //if (!string.IsNullOrEmpty(input.Tree) && 
            //    !RegexUtilities.IsValidMongoObjectId(input.Tree))
            //    throw new InvalidTreeObjectIdException();

            if (input.TreeId != null && 
                !await VerifyTreeExists((int)input.TreeId))
                throw new InvalidTreeIdException();

            _mapper.Map(input, partner);
            _partnerRepository.Update(partner);
            return new UpdatePartnerUseCaseOutput();
        }

        private async Task<bool> VerifyEmailExists(string email, int id)
        {
            var partner = await _partnerRepository.GetPartnerByEmail(email);

            if (partner is null)
            {
                return false;
            }

            if (partner.Id == id)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> VerifyTreeExists(int objectId)
            => await _treeRepository.VerifyTreeExistenceById(objectId);
    }
}
