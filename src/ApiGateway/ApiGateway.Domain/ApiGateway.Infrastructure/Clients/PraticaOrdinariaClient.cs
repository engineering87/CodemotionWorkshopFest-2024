using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;
using ApiGateway.Application.Interfaces;
using ApiGateway.Infrastructure.Api.Extensions;
using System.Net.Http.Json;

namespace ApiGateway.Infrastructure.Api.Clients
{
    public class PraticaOrdinariaClient(HttpClient client, IConfigManager config) : IPraticaOrdinariaClient
    {
        private readonly HttpClient _client = client;
        private readonly IConfigManager _config = config;
        private readonly Uri _baseUri = new(config.PraticaOrdinariaBaseUri);

        public async Task<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>?> GetPratiche(string? searchInput, int? pageNumber = null, int? pageSize = null)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.GetAllPraticheOrdinariePath)
                    .AddQueryParam("SearchInput", searchInput)
                    .AddQueryParam("PageNumber", pageNumber)
                    .AddQueryParam("PageSize", pageSize);

                return await _client.GetFromJsonAsync<PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>>(uri);
            }
            catch (Exception ex)
            {
                return new PagedResponse<IEnumerable<PraticaOrdinariaViewModel>>(null, pageNumber ?? 1, pageSize ?? int.MaxValue) 
                { 
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<PraticaOrdinariaViewModel>?> GetPraticaById(Guid id)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.GetPraticaOrdinariaByIdPath)
                    .Append(id.ToString());

                return await _client.GetFromJsonAsync<Response<PraticaOrdinariaViewModel>>(uri);
            }
            catch (Exception ex)
            {
                return new Response<PraticaOrdinariaViewModel>(null, ex.Message);
            }
        }

        public async Task<Response<IEnumerable<PraticaOrdinariaViewModel>>?> GetPraticheByBeneficiarioId(Guid beneficiarioId)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.GetPraticheOrdinarieByBeneficiarioIdPath)
                    .Append(beneficiarioId.ToString());

                return await _client.GetFromJsonAsync<Response<IEnumerable<PraticaOrdinariaViewModel>>>(uri);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PraticaOrdinariaViewModel>>(null, ex.Message);
            }
        }

        public async Task<Response<int>?> CountPratiche()
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.CountPraticheOrdinariePath);

                return await _client.GetFromJsonAsync<Response<int>>(uri);
            }
            catch (Exception ex)
            {
                return new Response<int>(0, ex.Message);
            }
        }
    }
}
