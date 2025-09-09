using System.Text.Json.Serialization;

namespace ViraRankCleanApi.DTOs
{
    public class AnalyzeSeoRequest
    {
        public string Html { get; set; } = "";
    }

    public class SeoAnalysisResponse
    {
        [JsonPropertyName("seo_friendly")]
        public bool SeoFriendly { get; set; }
        public double Probability { get; set; }
        [JsonPropertyName("top_class")]
        public string TopClass { get; set; } = "";
    }
}
