using Codemotion_DashboardLegacy.Data.API;
using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Clients
{
    public class PraticaStraordinariaClient : BaseClient
    {
        private static readonly Uri _baseUri = new Uri(ConfigurationManager.AppSettings["PraticaStraordinariaBaseUri"]);

        private static readonly string _getAllPratichePath = ConfigurationManager.AppSettings["GetAllPraticheStraordinariePath"];
        private static readonly string _getPraticheByBeneficiarioIdPath = ConfigurationManager.AppSettings["GetPraticheStraordinarieByBeneficiarioIdPath"];
        private static readonly string _getPraticaByIdPath = ConfigurationManager.AppSettings["GetPraticaStraordinariaByIdPath"];
        private static readonly string _countPratichePath = ConfigurationManager.AppSettings["CountPraticheStraordinariePath"];

        public async Task<IEnumerable<PraticaStraordinariaViewModel>> GetPratiche(string searchInput, int? pageNumber = null, int? pagesize = null)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getAllPratichePath)
                    .AddQueryParam("SearchInput", searchInput)
                    .AddQueryParam("PageNumber", pageNumber)
                    .AddQueryParam("PageSize", pagesize);

                var result = await DoGet<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return Enumerable.Empty<PraticaStraordinariaViewModel>();
            }
        }

        public async Task<PraticaStraordinariaViewModel> GetPraticaById(Guid id)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getPraticaByIdPath)
                    .Append(id.ToString());

                var result = await DoGet<Response<PraticaStraordinariaViewModel>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<PraticaStraordinariaViewModel>> GetPraticheByBeneficiarioId(Guid beneficiarioId)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getPraticheByBeneficiarioIdPath)
                    .Append(beneficiarioId.ToString());

                var result = await DoGet<Response<IEnumerable<PraticaStraordinariaViewModel>>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return Enumerable.Empty<PraticaStraordinariaViewModel>();
            }
        }

        public async Task<int> CountPratiche()
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_countPratichePath);

                var result = await DoGet<Response<int>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}