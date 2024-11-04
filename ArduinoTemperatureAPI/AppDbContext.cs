using Microsoft.EntityFrameworkCore;

namespace ArduinoTemperatureAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TemperatureRecord> temperatura { get; set; }
    }

    public class TemperatureRecord
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public decimal temperatura { get; set; }
    }
}
