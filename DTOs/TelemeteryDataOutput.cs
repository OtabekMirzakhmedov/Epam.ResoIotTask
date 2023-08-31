namespace Epam.ResoIotTask.DTOs
{
    public record TelemeteryDataOutput
    {
        public string Date { get; set; }
        public double MaxIlluminance { get; set; }
    }
}
