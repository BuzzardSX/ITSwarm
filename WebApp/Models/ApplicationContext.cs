using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
		public DbSet<Residence> Residences { get; set; }
		public DbSet<Meter> Meters { get; set; }
		public DbSet<MeterReading> MeterReadings { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Residence>(e =>
			{
				e.HasKey(r => r.Address);
			});
			modelBuilder.Entity<Meter>(e =>
			{
				e.HasKey(m => m.SerialNumber);
			});
			modelBuilder.Entity<MeterReading>(e =>
			{
				e.HasKey(r => new { r.MeterSerialNumber, r.CheckDate });
			});
		}
	}
}
