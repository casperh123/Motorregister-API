using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Models;

namespace MotorRegister.Infrastrucutre.Database;

public sealed class MotorRegisterDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleInformation> VehicleInformations { get; set; }
    public DbSet<VehicleDesignation> VehicleDesignations { get; set; }
    public DbSet<InspectionResult> InspectionResults { get; set; }
    public DbSet<Permit> Permits { get; set; }

    public MotorRegisterDbContext(DbContextOptions<MotorRegisterDbContext> contextOptions) : base(contextOptions)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Permit>()
            .HasKey(p => new {p.PermitType, p.Comment, p.ValidFrom});

        modelBuilder.Entity<VehicleInformation>()
            .HasKey(vd => vd.ChassisNumber);
    }
}