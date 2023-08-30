using Epam.ResoIotTask.DTOs;
using Epam.ResoIotTask.Models;
using Epam.ResoIotTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epam.ResoIotTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly ITelemetryService _telemetryService;

        public TelemetryController(ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
        }

        [HttpPost("{deviceId}/telemetry")]
        public async Task<IActionResult> PostTelemetry(int deviceId, [FromBody] List<TelemetryDataInput> telemetryInput)
        {

            await _telemetryService.AddData(deviceId, telemetryInput);

            return Ok();
        }
    }
}
