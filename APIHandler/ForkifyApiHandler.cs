using System.Net;
using System.Net.Mime;
using System.Text;
using FoodApplication.APIHandler.CreateRecipe;
using FoodApplication.APIHandler.GetRecipe;
using FoodApplication.Extensions;
using FoodApplication.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace FoodApplication.APIHandler;

public class ForkifyApiHandler : IForkifyApiHandler
{
    private readonly IOptions<ApiSettings> _options;
    private readonly IHttpClientFactory _client;

    public ForkifyApiHandler(IHttpClientFactory client, IOptions<ApiSettings> options)
    {
        _options = options;
        _client = client;
    }

    public async Task<CreateRecipeResponse> CreateRecipe(CreateRecipeRequest request, string searchParam)
    {
        try
        {
            string jsonContent = JsonConvert.SerializeObject(request);
            StringContent content = new(jsonContent, Encoding.UTF8, MediaTypeNames.Application.Json);
            var endpoint = string.Format(_options.Value.Endpoints.GetAllOrCreateRecipeEndpoint, searchParam, _options.Value.ApiKey);
            var httpClient = _client.CreateClient(_options.Value.ClientName);

            if (!httpClient.DefaultRequestHeaders.Contains(HeaderNames.Accept))
            {
                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);
            }

            var response = await httpClient.PostAsync(endpoint, content);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var data = await response.ReadContentAs<CreateRecipeResponse>();
                return data;
            }

            throw new HttpRequestException($"Unexpected error: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred.", ex);
        }
    }

    public async Task<GetRecipeResponse> GetRecipeList(string searchParam)
    {
        try
        {
            var endpoint = string.Format(_options.Value.Endpoints.GetAllOrCreateRecipeEndpoint, searchParam);
            var httpClient = _client.CreateClient(_options.Value.ClientName);
            var response = await httpClient.GetAsync(endpoint);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var data = await response.ReadContentAs<GetRecipeResponse>();
                return data;
            }

            throw new HttpRequestException($"Unexpected error: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred.", ex);
        }
    }
}
