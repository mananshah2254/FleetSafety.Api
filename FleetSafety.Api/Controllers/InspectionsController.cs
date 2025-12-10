using FleetSafety.Api.Data;
using FleetSafety.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetSafety.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InspectionsController : ControllerBase
    {
        private readonly FleetContext _context;

        public InspectionsController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/inspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionRecord>>> GetInspections()
{
    var inspections = await _context.InspectionRecords
        .Include(i => i.Driver)
        .Include(i => i.Vehicle)
        .OrderByDescending(i => i.InspectionDate)
        .ToListAsync();

    return inspections;
}

        // GET: api/inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionRecord>> GetInspection(int id)
        {
            var inspection = await _context.InspectionRecords
                .Include(i => i.Driver)
                .Include(i => i.Vehicle)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inspection == null)
                return NotFound();

            return inspection;
        }

        // POST: api/inspections
        [HttpPost]
        public async Task<ActionResult<InspectionRecord>> CreateInspection(InspectionRecord record)
{
    if (!await _context.Drivers.AnyAsync(d => d.Id == record.DriverId))
        return BadRequest("Driver does not exist.");

    if (!await _context.Vehicles.AnyAsync(v => v.Id == record.VehicleId))
        return BadRequest("Vehicle does not exist.");

    _context.InspectionRecords.Add(record);
    await _context.SaveChangesAsync();

    // Optional: load navs for response
    await _context.Entry(record).Reference(r => r.Driver).LoadAsync();
    await _context.Entry(record).Reference(r => r.Vehicle).LoadAsync();

    return CreatedAtAction(nameof(GetInspection), new { id = record.Id }, record);
}
    }
}
