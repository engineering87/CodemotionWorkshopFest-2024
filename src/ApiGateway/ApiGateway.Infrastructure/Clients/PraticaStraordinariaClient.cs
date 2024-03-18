using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Wrappers;
using ApiGateway.Application.Interfaces;
using ApiGateway.Infrastructure.Api.Extensions;
using System.Net.Http.Json;

namespace ApiGateway.Infrastructure.Api.Clients
{
    public class PraticaStraordinariaClient(HttpClient client, IConfigManager config) : IPraticaStraordinariaClient
    {
        private readonly HttpClient _client = client;
        private readonly IConfigManager _config = config;
        private readonly Uri _baseUri = new(config.PraticaStraordinariaBaseUri);

        public async Task<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>?> GetPratiche(string? searchInput, int? pageNumber = null, int? pageSize = null)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.GetAllPraticheStraordinariePath)
                    .AddQueryParam("SearchInput", searchInput)
                    .AddQueryParam("PageNumber", pageNumber)
                    .AddQueryParam("PageSize", pageSize);

                return await _client.GetFromJsonAsync<PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>>(uri);
            }
            catch (Exception ex)
            {
                return new PagedResponse<IEnumerable<PraticaStraordinariaViewModel>>(null, pageNumber ?? 1, pageSize ?? int.MaxValue) 
                { 
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<PraticaStraordinariaViewModel>?> GetPraticaById(Guid id)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.GetPraticaStraordinariaByIdPath)
                    .Append(id.ToString());

                return await _client.GetFromJsonAsync<Response<PraticaStraordinariaViewModel>>(uri);
            }
            catch (Exception ex)
            {
                return new Response<PraticaStraordinariaViewModel>(null, ex.Message);
            }
        }

        public async Task<Response<IEnumerable<PraticaStraordinariaViewModel>>?> GetPraticheByBeneficiarioId(Guid beneficiarioId)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.GetPraticheStraordinarieByBeneficiarioIdPath)
                    .Append(beneficiarioId.ToString());

                return await _client.GetFromJsonAsync<Response<IEnumerable<PraticaStraordinariaViewModel>>>(uri);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PraticaStraordinariaViewModel>>(null, ex.Message);
            }
        }

        public async Task<Response<int>?> CountPratiche()
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.CountPraticheStraordinariePath);

                return await _client.GetFromJsonAsync<Response<int>>(uri);
            }
            catch (Exception ex)
            {
                return new Response<int>(0, ex.Message);
            }
        }
    }
}
