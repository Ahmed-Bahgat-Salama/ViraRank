using System.Net.Http.Json;
using ViraRankCleanApi.DTOs;

namespace ViraRankCleanApi.Services
{
    public class SeoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SeoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SeoAnalysisResponse?> AnalyzeHtml(string htmlContent)
        {
            if (string.IsNullOrWhiteSpace(htmlContent))
            {
                throw new ArgumentException("HTML content cannot be empty.");
            }

            var aiClient = _httpClientFactory.CreateClient("AiModel");
            var requestData = new { html = htmlContent };

          
            var response = await aiClient.PostAsJsonAsync("predict", requestData);

            response.EnsureSuccessStatusCode(); 

            return await response.Content.ReadFromJsonAsync<SeoAnalysisResponse>();
        }
    }
}

