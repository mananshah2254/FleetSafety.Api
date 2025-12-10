namespace FleetSafety.Api.Models
{
    public class InspectionRecord
    {
        public int Id { get; set; }

        public int DriverId { get; set; }
        public int VehicleId { get; set; }

        public DateTime InspectionDate { get; set; }
        public string Location { get; set; } = null!;
        public string Result { get; set; } = null!; // "Pass" / "Fail"
        public int ViolationCount { get; set; }
        public bool IsOutOfService { get; set; }
        public string? Notes { get; set; }

        public Driver? Driver { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
