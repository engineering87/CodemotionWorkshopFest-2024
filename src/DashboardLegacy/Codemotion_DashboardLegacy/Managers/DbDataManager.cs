using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Models;
using Codemotion_DashboardLegacy.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Managers
{
    public class DbDataManager : IDataManager
    {
        private readonly IPraticheRepository _praticheRepository = new PraticheRepository();
        private readonly IBeneficiariRepository _beneficiariRepository = new BeneficiariRepository();

        public async Task<IEnumerable<PraticaOrdinariaViewModel>> GetPraticheOrdinarie(string searchInput)
        {
            var result = await _praticheRepository.GetPraticheOrdinarie(searchInput);

            return result;
        }

        public async Task<IEnumerable<PraticaStraordinariaViewModel>> GetPraticheStraordinarie(string searchInput)
        {
            var result = await _praticheRepository.GetPraticheStraordinarie(searchInput);

            return result;
        }

        public async Task<IEnumerable<PraticaViewModel>> GetPraticheByBeneficiarioId(Guid beneficiarioId)
        {
            var result = await _praticheRepository.GetPraticheByBeneficiarioId(beneficiarioId);

            return result;
        }

        public async Task<ContatoriPratiche> GetContatoriPratiche()
        {
            var result = await _praticheRepository.GetContatoriPratiche();

            return result;
        }

        public async Task<IEnumerable<BeneficiarioViewModel>> GetBeneficiari(string searchInput)
        {
            var result = await _beneficiariRepository.GetBeneficiari(searchInput);

            return result;
        }
    }
}