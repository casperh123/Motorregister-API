using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Entities;
using DriveType = MotorRegister.Core.Entities.DriveType;

namespace MotorRegister.Infrastrucutre.Database;

public sealed class MotorRegisterDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<InspectionResult> InspectionResults { get; set; }

    public MotorRegisterDbContext(DbContextOptions<MotorRegisterDbContext> contextOptions) : base(contextOptions)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vehicle>()
            .OwnsOne(v => v.Information, info =>
            {
                info.OwnsOne(i => i.Designation);
            })
            .HasOne(v => v.DriveType);
        
        modelBuilder.Entity<InspectionResult>()
            .HasKey(i => new { i.Id, i.Date });
        
        modelBuilder.Entity<Usage>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Usage>()
            .Property(u => u.Id)
            .ValueGeneratedNever();
        
        modelBuilder.Entity<DriveType>()
            .HasKey(dt => new { dt.VehicleId });

    }
}