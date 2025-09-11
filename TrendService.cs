using System.Net.Http.Json;
using ViraRankCleanApi.DTOs;

namespace ViraRankCleanApi.Services
{
    public class TrendService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TrendService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TrendAnalysisResponse?> AnalyzeTrend(TrendAnalysisRequest request)
        {
         
            var trendClient = _httpClientFactory.CreateClient("TrendModel");

            
            var response = await trendClient.PostAsJsonAsync("predict", request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TrendAnalysisResponse>();
        }
    }
}
