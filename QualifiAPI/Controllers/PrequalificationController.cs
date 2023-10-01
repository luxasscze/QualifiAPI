using Microsoft.AspNetCore.Mvc;
using QualifiAPI.Models;
using QualifiAPI.Services.Interfaces;

namespace QualifiAPI.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class PrequalificationController : ControllerBase
    {
        private readonly IPrequalificationService _prequalificationService;

        public PrequalificationController(IPrequalificationService prequalificationService)
        {
            _prequalificationService = prequalificationService;
        }

        /// <summary>
        /// API endpoint - Prequalification decision
        /// </summary>
        /// <param name="application">input parameters</param>
        /// <returns>credit card list with available credit card offers based on data from "application"</returns>
        [HttpPost("prequalification")]
        public async Task<IActionResult> Prequalification([FromBody] Application application)
        {
            List<CreditCard>? creditCards = await _prequalificationService.PrequalifyApplicant(application);
            
            return Ok(creditCards);
        }
    }
}