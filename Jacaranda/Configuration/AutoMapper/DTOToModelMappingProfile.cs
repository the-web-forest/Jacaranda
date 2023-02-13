using AutoMapper;
using Jacaranda.Controllers.Partners.DTOs;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.CreatePartners;
using Jacaranda.UseCase.ListPartners;
using Jacaranda.UseCase.UpdatePartner;

namespace Jacaranda.Configuration.AutoMapper
{
    public class DtoToModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return GetType().Name; }
        }

        public DtoToModelMappingProfile()
        {
            CreateMap<PartnersSearchInput, ListPartnersUseCaseInput>();
            CreateMap<CreatePartnerInput, CreatePartnerUseCaseInput>();
            CreateMap<CreatePartnerUseCaseInput, Partner>()
                .BeforeMap((s, d) => d.Deleted = false);
            CreateMap<UpdatePartnerInput, UpdatePartnerUseCaseInput>();
            CreateMap<UpdatePartnerUseCaseInput, Partner>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Code, y => y.Ignore())
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember is not null));
        }
    }
}
