using System.Text.Json.Serialization;

namespace ViraRankCleanApi.DTOs
{
    // كلاس يمثل البيانات التي سنرسلها للموديل
    public class TrendAnalysisRequest
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = "";

        [JsonPropertyName("platform")]
        public string Platform { get; set; } = "";
    }


    public class TrendAnalysisResponse
    {
        [JsonPropertyName("viral")]
        public bool IsViral { get; set; }

        [JsonPropertyName("probability")]
        public float Probability { get; set; }
    }
}
