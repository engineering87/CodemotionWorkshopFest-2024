using Codemotion_DashboardLegacy.Clients;
using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Managers
{
    public class ApiDataManager : IDataManager
    {
        private readonly PraticaOrdinariaClient _praticaOrdinariaClient = new PraticaOrdinariaClient();
        private readonly PraticaStraordinariaClient _praticaStraordinariaClient = new PraticaStraordinariaClient();
        private readonly BeneficiarioClient _beneficiarioClient = new BeneficiarioClient();
        
        public async Task<IEnumerable<PraticaOrdinariaViewModel>> GetPraticheOrdinarie(string searchInput)
        {
            var result = await _praticaOrdinariaClient.GetPratiche(searchInput);

            return result;
        }

        public async Task<IEnumerable<PraticaStraordinariaViewModel>> GetPraticheStraordinarie(string searchInput)
        {
            var result = await _praticaStraordinariaClient.GetPratiche(searchInput);

            return result;
        }

        public async Task<IEnumerable<PraticaViewModel>> GetPraticheByBeneficiarioId(Guid beneficiarioId)
        {
            var result = new List<PraticaViewModel>();

            var (task1, task2) = (
                _praticaOrdinariaClient.GetPraticheByBeneficiarioId(beneficiarioId),
                _praticaStraordinariaClient.GetPraticheByBeneficiarioId(beneficiarioId)
            );

            await Task.WhenAll(task1, task2);

            result.AddRange(task1.Result);
            result.AddRange(task2.Result);

            return result;
        }

        public async Task<IEnumerable<BeneficiarioViewModel>> GetBeneficiari(string searchInput)
        {
            var result = await _beneficiarioClient.GetBeneficiari(searchInput);

            return result;
        }

        public async Task<ContatoriPratiche> GetContatoriPratiche()
        {
            var (task1, task2) = (
                _praticaOrdinariaClient.CountPratiche(),
                _praticaStraordinariaClient.CountPratiche()
            );

            await Task.WhenAll(task1, task2);

            var result = new ContatoriPratiche()
            {
                ContatorePraticheOrdinarie = task1.Result,
                ContatorePraticheStraordinarie = task2.Result
            };

            return result;
        }
    }
}