using Epam.ResoIotTask.Models;
using Microsoft.EntityFrameworkCore;

namespace Epam.ResoIotTask.Data
{
    public class TelemetryContext : DbContext
    {
        public TelemetryContext(DbContextOptions<TelemetryContext> options) : base(options)
        {
        }

        public DbSet<TelemetryData> TelemetryDatas { get; set; }
    }
}
