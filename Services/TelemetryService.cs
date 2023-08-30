using Epam.ResoIotTask.Data;
using Epam.ResoIotTask.DTOs;
using Epam.ResoIotTask.Models;

namespace Epam.ResoIotTask.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly TelemetryContext _context;

        public TelemetryService(TelemetryContext context)
        {
            _context = context;
        }
        public async Task AddData(int deviceId, List<TelemetryDataInput> telemetryInputs)
        {
            foreach (var telemetry in telemetryInputs)
            {

                var telemetryData = new TelemetryData
                {
                    DeviceId = deviceId,
                    Illuminance = telemetry.Illuminance,
                    TimeStamp = telemetry.TimeStamp
                };

                _context.TelemetryDatas.Add(telemetryData);
            }

            await _context.SaveChangesAsync();
        }
    }
}
