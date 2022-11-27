using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertsService _alertsApiService;

        public AlertsController(IAlertsService alertsApiService)
        {
            _alertsApiService = alertsApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new OkObjectResult(await _alertsApiService.GetAllAsync());
        }
    }
}
