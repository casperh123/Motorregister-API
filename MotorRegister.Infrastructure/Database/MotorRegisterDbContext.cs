using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Entities;

namespace MotorRegister.Infrastrucutre.Database;

public sealed class MotorRegisterDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleInformation> VehicleInformations { get; set; }
    public DbSet<InspectionResult> InspectionResults { get; set; }

    public MotorRegisterDbContext(DbContextOptions<MotorRegisterDbContext> contextOptions) : base(contextOptions)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VehicleInformation>()
            .HasKey(vd => vd.ChassisNumber);

        modelBuilder.Entity<InspectionResult>()
            .HasKey(i => new { i.VehicleId, i.StatusDate });
    }
}