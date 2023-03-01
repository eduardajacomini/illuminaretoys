using IlluminareToys.Domain.Shared.Extensions;
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

        public async Task<GetProductsResponse> GetProductsAsync(CancellationToken cancellationToken)
        {
            var apiKey = _configuration["BlingApiKey"];
            var url = $"/Api/v2/produtos/page=@page/json?apikey={apiKey}&estoque=S";
            var pageToSearch = 1;
            GetProductsResponse finalResponse = new();

            var continueLoop = true;

            while (continueLoop)
            {
                var response = await _httpClient.GetAsync(url.Replace("@page", pageToSearch.ToString()), cancellationToken);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync(cancellationToken);

                var products = JsonConvert.DeserializeObject<GetProductsResponse>(content);

                finalResponse.Response.Products.AddRange(products.Response.Products);

                if (products.Response.Products.Count == 100)
                {
                    continueLoop = true;

                    pageToSearch++;

                    continue;
                }

                continueLoop = false;
            }

            return finalResponse;
        }

        public async Task PutImageInProductAsync(PutImageInProductRequest request, CancellationToken cancellationToken)
        {
            var apiKey = _configuration["BlingApiKey"];
            var url = $"/Api/v2/produto/{request.Code}/json/";

            var xml = request.ToXml();

            var dict = new Dictionary<string, string>();
            dict.Add("apikey", apiKey);
            dict.Add("xml", xml);

            var response = await _httpClient.PostAsync(url, new FormUrlEncodedContent(dict), cancellationToken);

            response.EnsureSuccessStatusCode();
        }
    }
}
