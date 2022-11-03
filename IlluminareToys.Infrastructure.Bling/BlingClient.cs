using IlluminareToys.Infrastructure.Bling.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IlluminareToys.Infrastructure.Bling
{
    public class BlingClient : IBlingClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public BlingClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("Bling");
            _httpClient.BaseAddress = new Uri(configuration["BlingApiUrl"]);
            _configuration = configuration;
        }

        public async Task<GetProductsResponse> GetProductsAsync()
        {
            var apiKey = _configuration["BlingApiKey"];
            var response = await _httpClient.GetAsync($"/Api/v2/produtos/json?apikey={apiKey}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var produts = JsonConvert.DeserializeObject<GetProductsResponse>(content);

            return produts;
        }
    }
}
