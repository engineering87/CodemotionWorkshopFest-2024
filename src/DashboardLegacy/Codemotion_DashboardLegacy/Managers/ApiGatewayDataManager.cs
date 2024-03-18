using Codemotion_DashboardLegacy.Clients;
using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Managers
{
    public class ApiGatewayDataManager : IDataManager
    {
        private readonly GatewayClient _gatewayClient = new GatewayClient();
        
        public async Task<IEnumerable<PraticaOrdinariaViewModel>> GetPraticheOrdinarie(string searchInput)
        {
            var result = await _gatewayClient.GetPraticheOrdinarie(searchInput);

            return result;
        }

        public async Task<IEnumerable<PraticaStraordinariaViewModel>> GetPraticheStraordinarie(string searchInput)
        {
            var result = await _gatewayClient.GetPraticheStraordinarie(searchInput);

            return result;
        }

        public async Task<IEnumerable<PraticaViewModel>> GetPraticheByBeneficiarioId(Guid beneficiarioId)
        {
            var result = await _gatewayClient.GetPraticheByBeneficiarioId(beneficiarioId);

            return result;
        }

        public async Task<IEnumerable<BeneficiarioViewModel>> GetBeneficiari(string searchInput)
        {
            var result = await _gatewayClient.GetBeneficiari(searchInput);

            return result;
        }

        public async Task<ContatoriPratiche> GetContatoriPratiche()
        {
            var result = await _gatewayClient.CountPratiche();

            return result;
        }
    }
}