namespace FleetSafety.Api.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string TruckNumber { get; set; } = null!;
        public string PlateNumber { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }

        public ICollection<InspectionRecord> Inspections { get; set; } = new List<InspectionRecord>();
    }
}
