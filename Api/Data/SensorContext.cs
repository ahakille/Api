using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class SensorContext : DbContext
    {
        public SensorContext(DbContextOptions<SensorContext> options)
            : base(options)
        {
        }

        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<Measure> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var sensor = builder.Entity<Sensor>();
            sensor.HasKey(s => s.SensorId);
            sensor.Property(s => s.SensorId).UseNpgsqlSerialColumn();
            sensor.Property(s => s.SensorName).HasMaxLength(250);

            var measure = builder.Entity<Measure>();
            measure.HasKey(m => m.MeasureId);
            measure.Property(m => m.MeasureId).UseNpgsqlSerialColumn();
            measure.Property(m => m.SensorId).IsRequired();
            measure.Property(m => m.SensorData).IsRequired().HasMaxLength(250);
            measure.Property(m => m.TimeStamp).IsRequired();

        }
    }
}