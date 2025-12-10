using System.Text.Json.Serialization;

namespace FleetSafety.Api.Models
{
    public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LicenseNumber { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }

    [JsonIgnore]
    public ICollection<InspectionRecord>? Inspections { get; set; }
}

}
