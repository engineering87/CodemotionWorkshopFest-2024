using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Repository
{
    public interface IPraticheRepository
    {
        Task<ContatoriPratiche> GetContatoriPratiche();
        Task<IEnumerable<PraticaViewModel>> GetPraticheByBeneficiarioId(Guid beneficiarioId);
        Task<IEnumerable<PraticaOrdinariaViewModel>> GetPraticheOrdinarie(string input);
        Task<IEnumerable<PraticaStraordinariaViewModel>> GetPraticheStraordinarie(string input);
    }
}