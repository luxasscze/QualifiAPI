using Microsoft.AspNetCore.Mvc;
using QualifiAPI.Models;
using QualifiAPI.Services.Interfaces;

namespace QualifiAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PrequalificationController : ControllerBase
    {
        private readonly ILogger<PrequalificationController> _logger;
        private readonly IPrequalificationService _prequalificationService;

        public PrequalificationController(ILogger<PrequalificationController> logger, IPrequalificationService prequalificationService)
        {
            _logger = logger;
            _prequalificationService = prequalificationService;
        }

        [HttpPost(Name = "prequalification")]
        public async Task<IActionResult> Prequalification([FromBody] PrequalificationRequest payload)
        {
            return Ok(await _prequalificationService.PrequalificationRequestSave(payload));
        }
    }
}