using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Managers
{
    public interface IDataManager
    {
        Task<IEnumerable<BeneficiarioViewModel>> GetBeneficiari(string searchInput);
        Task<ContatoriPratiche> GetContatoriPratiche();
        Task<IEnumerable<PraticaViewModel>> GetPraticheByBeneficiarioId(Guid beneficiarioId);
        Task<IEnumerable<PraticaOrdinariaViewModel>> GetPraticheOrdinarie(string searchInput);
        Task<IEnumerable<PraticaStraordinariaViewModel>> GetPraticheStraordinarie(string searchInput);
    }
}