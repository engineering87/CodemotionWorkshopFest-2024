using AutoMapper;
using Beneficiari.Application.Features.Beneficiari.Queries.GetAllBeneficiari;
using Beneficiari.Application.Features.Beneficiari.ViewModels;
using Beneficiari.Domain.Entities;

namespace Beneficiari.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Beneficiario, BeneficiarioViewModel>();
            CreateMap<GetAllBeneficiariQuery, GetAllBeneficiariParameter>();
        }
    }
}
