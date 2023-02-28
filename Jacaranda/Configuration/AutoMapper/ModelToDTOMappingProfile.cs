using AutoMapper;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.ListPartners;
using Jacaranda.UseCase.ListPartners.DTOs;
using Jacaranda.UseCase.GetPartnerById;

namespace Jacaranda.Configuration.AutoMapper
{
    public class ModelToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return GetType().Name; }
        }

        public ModelToDtoMappingProfile()
        {
            CreateMap<Partner, LightPartner>();

            CreateMap<Paging<Partner>, ListPartnersUseCaseOutput>()
                .ForMember(x => x.Partners, y => y.MapFrom(z => z.Data))
                .ForMember(x => x.TotalCount, y => y.MapFrom(z => z.TotalCount));

            CreateMap<Partner, GetPartnerByIdUseCaseOutput>();
        }
    }
}
