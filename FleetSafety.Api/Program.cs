using FleetSafety.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// DB context
builder.Services.AddDbContext<FleetContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection");
    Console.WriteLine("**** USING CONNECTION STRING ****");
    Console.WriteLine(cs);
    Console.WriteLine("*********************************");
    options.UseSqlServer(cs);
});

var app = builder.Build();

// Try to apply migrations with a small retry
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FleetContext>();

    var retries = 5;
    while (retries > 0)
    {
        try
        {
            db.Database.Migrate();
            Console.WriteLine("Database migration succeeded.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Migration failed, retries left {retries - 1}: {ex.Message}");
            Thread.Sleep(5000);
            retries--;
        }
    }
}

// No HTTPS redirect in container
// app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
