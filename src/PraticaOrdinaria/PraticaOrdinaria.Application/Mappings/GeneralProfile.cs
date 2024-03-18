using AutoMapper;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.Queries.GetAllPraticheOrdinarie;
using PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels;
using PraticaOrdinaria.Domain.Entities.Legacy;

namespace PraticaOrdinaria.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Domain.Entities.PraticaOrdinaria, PraticaOrdinariaViewModel>()
                .ForMember(
                    dest => dest.Pagamento,
                    opt => opt.MapFrom(src => src.Pagamento));

            CreateMap<Domain.Entities.TipoPagamento, TipoPagamentoViewModel>();

            CreateMap<GetAllPraticheOrdinarieQuery, GetAllPraticheOrdinarieParameter>();

            CreateMap<PraticaLegacy, PraticaOrdinariaViewModel>()
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
                    dest => dest.Pagamento.Id,
                    opt => opt.MapFrom(src => src.Pagamento.ID))
                .ForPath(
                    dest => dest.Pagamento.Descrizione,
                    opt => opt.MapFrom(src => src.Pagamento.DESCRIPTION));

            CreateMap<GetAllPraticheOrdinarieQueryLegacy, GetAllPraticheOrdinarieParameter>();
        }
    }
}
