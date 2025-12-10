using FleetSafety.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetSafety.Api.Data
{
    public class FleetContext : DbContext
    {
        public FleetContext(DbContextOptions<FleetContext> options)
            : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<InspectionRecord> InspectionRecords { get; set; } = null!;
    }
}
