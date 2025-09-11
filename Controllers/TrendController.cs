using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViraRankCleanApi.DTOs;
using ViraRankCleanApi.Services;

namespace ViraRankCleanApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TrendController : ControllerBase
    {
        private readonly TrendService _trendService;

        public TrendController(TrendService trendService)
        {
            _trendService = trendService;
        }

        [HttpPost("analyze")]
        public async Task<ActionResult<TrendAnalysisResponse>> Analyze(TrendAnalysisRequest request)
        {
            try
            {
                var result = await _trendService.AnalyzeTrend(request);
                if (result == null)
                {
                    return StatusCode(500, "Failed to get a valid response from the trend model.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An internal server error occurred: {ex.Message}");
            }
        }
    }
}
