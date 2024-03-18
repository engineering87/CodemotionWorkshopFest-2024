using Codemotion_DashboardLegacy.Data.API;
using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Extensions;
using Codemotion_DashboardLegacy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Clients
{
    public class GatewayClient : BaseClient
    {
        private static readonly Uri _baseUri = new Uri(ConfigurationManager.AppSettings["GatewayBaseUri"]);

        private static readonly string _getAllPraticheOrdinariePath = ConfigurationManager.AppSettings["GetAllPraticheOrdinarieGWPath"];
        private static readonly string _getAllPraticheStraordinariePath = ConfigurationManager.AppSettings["GetAllPraticheStraordinarieGWPath"];
        private static readonly string _getPraticheByBeneficiarioIdPath = ConfigurationManager.AppSettings["GetPraticheByBeneficiarioIdGWPath"];
        private static readonly string _getPraticaByIdPath = ConfigurationManager.AppSettings["GetPraticaByIdGWPath"];
        private static readonly string _countPratichePath = ConfigurationManager.AppSettings["CountPraticheGWPath"];
        private static readonly string _getAllBeneficiariPath = ConfigurationManager.AppSettings["GetAllBeneficiariGWPath"];
        private static readonly string _getBeneficiarioByIdPath = ConfigurationManager.AppSettings["GetBeneficiarioByIdGWPath"];

        public async Task<IEnumerable<PraticaOrdinariaViewModel>> GetPraticheOrdinarie(string searchInput, int? pageNumber = null, int? pagesize = null)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getAllPraticheOrdinariePath)
                    .AddQueryParam("SearchInput", searchInput)
                    .AddQueryParam("PageNumber", pageNumber)
                    .AddQueryParam("PageSize", pagesize);

                var result = await DoGet<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return Enumerable.Empty<PraticaOrdinariaViewModel>();
            }
        }

        public async Task<IEnumerable<PraticaStraordinariaViewModel>> GetPraticheStraordinarie(string searchInput, int? pageNumber = null, int? pagesize = null)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getAllPraticheStraordinariePath)
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

        public async Task<PraticaViewModel> GetPraticaById(Guid id)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getPraticaByIdPath)
                    .Append(id.ToString());

                var result = await DoGet<Response<PraticaViewModel>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<PraticaViewModel>> GetPraticheByBeneficiarioId(Guid beneficiarioId)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_getPraticheByBeneficiarioIdPath)
                    .Append(beneficiarioId.ToString());

                var result = await DoGet<Response<IEnumerable<PraticaViewModel>>>(uri);

                return result.Data;
            }
            catch (Exception)
            {
                return Enumerable.Empty<PraticaViewModel>();
            }
        }

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

        public async Task<ContatoriPratiche> CountPratiche()
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_countPratichePath);

                var result = await DoGet<Response<ContatoriPratiche>>(uri);

                return result.Data ?? new ContatoriPratiche();
            }
            catch (Exception)
            {
                return new ContatoriPratiche();
            }
        }
    }
}