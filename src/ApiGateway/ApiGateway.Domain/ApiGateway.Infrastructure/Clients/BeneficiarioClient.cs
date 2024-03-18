using ApiGateway.Application.Features.ViewModels;
using ApiGateway.Application.Interfaces;
using ApiGateway.Application.Wrappers;
using ApiGateway.Infrastructure.Api.Extensions;
using System.Net.Http.Json;

namespace ApiGateway.Infrastructure.Api.Clients
{
    public class BeneficiarioClient(HttpClient client, IConfigManager config) : IBeneficiarioClient
    {
        private readonly HttpClient _client = client;
        private readonly IConfigManager _config = config;
        private readonly Uri _baseUri = new(config.BeneficiarioBaseUri);

        public async Task<PagedResponse<IEnumerable<BeneficiarioViewModel>>?> GetBeneficiari(string? searchInput, int? pageNumber = null, int? pageSize = null)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.GetAllBeneficiariPath)
                    .AddQueryParam("SearchInput", searchInput)
                    .AddQueryParam("PageNumber", pageNumber)
                    .AddQueryParam("PageSize", pageSize);

                return await _client.GetFromJsonAsync<PagedResponse<IEnumerable<BeneficiarioViewModel>>>(uri);
            }
            catch (Exception ex)
            {
                return new PagedResponse<IEnumerable<BeneficiarioViewModel>>(null, pageNumber ?? 1, pageSize ?? int.MaxValue)
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<BeneficiarioViewModel>?> GetBeneficiarioById(Guid id)
        {
            try
            {
                Uri uri = _baseUri
                    .Append(_config.GetBeneficiarioByIdPath)
                    .Append(id.ToString());

                return await _client.GetFromJsonAsync<Response<BeneficiarioViewModel>>(uri);
            }
            catch (Exception ex)
            {
                return new Response<BeneficiarioViewModel>(null, ex.Message);
            }
        }
    }
}
