namespace Epam.ResoIotTask.DTOs
{
    public record TelemetryDataInput
    {
        public double Illuminance { get; set; }
        public long TimeStamp { get; set; }
    }
}
