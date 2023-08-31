using Epam.ResoIotTask.DTOs;

namespace Epam.ResoIotTask.Services
{
    public interface ITelemetryService
    {
        Task AddData(int deviceId, List<TelemetryDataInput> dataInputs);

        Task<IEnumerable<TelemeteryDataOutput>> ShowStatistics(int deviceId);
           

    }
}
