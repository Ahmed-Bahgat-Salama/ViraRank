using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViraRankCleanApi.DTOs;
using ViraRankCleanApi.Services;

namespace ViraRankCleanApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class SeoController : ControllerBase
    {
        private readonly SeoService _seoService;

        public SeoController(SeoService seoService)
        {
            _seoService = seoService;
        }

        [HttpPost("analyze")]
        public async Task<ActionResult<SeoAnalysisResponse>> Analyze(AnalyzeSeoRequest request)
        {
            try
            {
               
                var result = await _seoService.AnalyzeHtml(request.Html);

                
                if (result == null)
                {
                    return StatusCode(500, "Failed to get a valid analysis from the AI model.");
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

