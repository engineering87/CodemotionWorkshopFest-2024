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
    public class BeneficiarioClient : BaseClient
    {
        private static readonly Uri _baseUri = new Uri(ConfigurationManager.AppSettings["BeneficiarioBaseUri"]);

        private static readonly string _getAllBeneficiariPath = ConfigurationManager.AppSettings["GetAllBeneficiariPath"];
        private static readonly string _getBeneficiarioByIdPath = ConfigurationManager.AppSettings["GetBeneficiarioByIdPath"];

        public async Task<IEnumerable<BeneficiarioViewModel>> GetBeneficiari(string searchInput, int? pageNumber = null, int? pagesize = null)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getAllBeneficiariPath)
                    .AddQueryParam("SearchInput", searchInput)
                    .AddQueryParam("PageNumber", pageNumber)
                    .AddQueryParam("PageSize", pagesize);

                var result = await DoGet<PagedResponse<IEnumerable<BeneficiarioViewModel>>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return Enumerable.Empty<BeneficiarioViewModel>();
            }
        }

        public async Task<BeneficiarioViewModel> GetBeneficiarioById(Guid id)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getBeneficiarioByIdPath)
                    .Append(id.ToString());

                var result = await DoGet<Response<BeneficiarioViewModel>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}