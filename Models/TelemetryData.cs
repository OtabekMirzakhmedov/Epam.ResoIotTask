using System.ComponentModel.DataAnnotations;

namespace Epam.ResoIotTask.Models
{
    public class TelemetryData
    {
        [Key]
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public double Illuminance { get; set; }
        public long TimeStamp { get; set; }
    }
}
