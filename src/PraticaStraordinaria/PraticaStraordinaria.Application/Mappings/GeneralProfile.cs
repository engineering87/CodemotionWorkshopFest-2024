using AutoMapper;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.Queries.GetAllPraticheStraordinarie;
using PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels;
using PraticaStraordinaria.Domain.Entities.Legacy;

namespace PraticaStraordinaria.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Domain.Entities.PraticaStraordinaria, PraticaStraordinariaViewModel>()
                .ForMember(
                    dest => dest.Causale,
                    opt => opt.MapFrom(src => src.Causale));

            CreateMap<Domain.Entities.Causale, CausaleViewModel>();

            CreateMap<GetAllPraticheStraordinarieQuery, GetAllPraticheStraordinarieParameter>();

            CreateMap<PraticaLegacy, PraticaStraordinariaViewModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.P_GUID))
                .ForMember(
                    dest => dest.Protocollo,
                    opt => opt.MapFrom(src => src.P_PTC))
                .ForMember(
                    dest => dest.DataInserimento,
                    opt => opt.MapFrom(src => src.P_DATAINS))
                .ForMember(
                    dest => dest.IdBeneficiario,
                    opt => opt.MapFrom(src => src.BEN_GUID))
                .ForPath(
                    dest => dest.Causale.Id,
                    opt => opt.MapFrom(src => src.Causali.ID))
                .ForPath(
                    dest => dest.Causale.Descrizione,
                    opt => opt.MapFrom(src => src.Causali.DESCRIPTION));

            CreateMap<GetAllPraticheStraordinarieQueryLegacy, GetAllPraticheStraordinarieParameter>();
        }
    }
}
