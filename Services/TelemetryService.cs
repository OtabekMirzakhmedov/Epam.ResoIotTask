using Epam.ResoIotTask.Data;
using Epam.ResoIotTask.DTOs;
using Epam.ResoIotTask.Models;
using Epam.ResoIotTask.Validations;
using Microsoft.EntityFrameworkCore;

namespace Epam.ResoIotTask.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly TelemetryContext _context;
        private readonly ITelemetryDataValidator _validator;

        public TelemetryService(TelemetryContext context,ITelemetryDataValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task AddData(int deviceId, List<TelemetryDataInput> telemetryInputs)
        {
            foreach (var telemetry in telemetryInputs)
            {
                if (_validator.IsValidIlluminance(telemetry))
                {

                    var telemetryData = new TelemetryData
                    {
                        DeviceId = deviceId,
                        Illuminance = telemetry.Illuminance,
                        TimeStamp = DateTimeOffset.FromUnixTimeSeconds(telemetry.TimeStamp).UtcDateTime
                    };

                    _context.TelemetryDatas.Add(telemetryData);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TelemeteryDataOutput>> ShowStatistics(int deviceId)
        {
            DateTime thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);

            var data = await _context.TelemetryDatas
                .Where(data => data.DeviceId == deviceId && data.TimeStamp >= thirtyDaysAgo)
                .GroupBy(data => data.TimeStamp.Date)
                .OrderByDescending(group => group.Key)
                .Select(group => new TelemeteryDataOutput
                {
                    Date = group.Key.Date.ToString("yyyy-MM-dd"),
                    MaxIlluminance = group.Max(data => data.Illuminance)
                })
                .ToListAsync();

            return data;
        }



    }
}
