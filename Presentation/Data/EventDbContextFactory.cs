using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Presentation.Data;

public class EventDbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
{
    public EventDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EventDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=event_service_db;Trusted_Connection=True;");

        return new EventDbContext(optionsBuilder.Options);
    }
}
