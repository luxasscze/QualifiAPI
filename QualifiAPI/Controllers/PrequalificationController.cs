using Microsoft.AspNetCore.Mvc;
using QualifiAPI.Models;
using QualifiAPI.Services.Interfaces;

namespace QualifiAPI.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class PrequalificationController : ControllerBase
    {
        private readonly ILogger<PrequalificationController> _logger;
        private readonly IPrequalificationService _prequalificationService;

        public PrequalificationController(ILogger<PrequalificationController> logger, IPrequalificationService prequalificationService)
        {
            _logger = logger;
            _prequalificationService = prequalificationService;
        }

        [HttpPost("prequalification")]
        public async Task<IActionResult> Prequalification([FromBody] Application application)
        {
            List<CreditCard>? creditCards = await _prequalificationService.PrequalifyApplicant(application);
            
            return Ok(creditCards);
        }

        [HttpGet("getallcc")]
        public async Task<IActionResult> GetAllCC()
        {
            return Ok(await _prequalificationService.GetAllCreditCards());
        }

        [HttpGet("getallrequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            return Ok(await _prequalificationService.GetAllRequests());
        }
    }
}