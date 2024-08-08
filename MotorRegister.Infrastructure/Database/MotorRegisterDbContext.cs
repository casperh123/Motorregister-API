using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Entities;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Infrastrucutre.Database;

public sealed class MotorRegisterDbContext : DbContext
{
    public DbSet<XmlVehicle> Vehicles { get; set; }
    public DbSet<XmlVehicleInformation> VehicleInformations { get; set; }
    public DbSet<XmlInspectionResult> InspectionResults { get; set; }

    public MotorRegisterDbContext(DbContextOptions<MotorRegisterDbContext> contextOptions) : base(contextOptions)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InspectionResult>()
            .HasKey(i => new { i.VehicleId, i.Date });
    }
}