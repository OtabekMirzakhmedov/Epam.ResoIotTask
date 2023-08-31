using Epam.ResoIotTask.DTOs;

namespace Epam.ResoIotTask.Validations
{
    public interface ITelemetryDataValidator
    {
        bool IsValidIlluminance(TelemetryDataInput telemetry);
    }
}
