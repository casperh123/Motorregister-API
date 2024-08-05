using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Models;

namespace MotorRegister.Infrastrucutre.Database;

public sealed class MotorRegisterDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }

    public MotorRegisterDbContext(DbContextOptions<MotorRegisterDbContext> contextOptions) : base(contextOptions)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VehicleDesignation>()
            .HasKey(v => new { v.ManufacturerId, v.ModelId, v.VariantId });
        // Configuring owned entities
        modelBuilder.Entity<VehicleDesignation>()
            .OwnsOne(v => v.Model);
        modelBuilder.Entity<VehicleDesignation>()
            .OwnsOne(v => v.Variant);
        modelBuilder.Entity<VehicleDesignation>()
            .OwnsOne(v => v.Type);

        modelBuilder.Entity<InspectionResult>()
            .HasKey(v => new { v.VehicleId, v.Date });
        
        
        modelBuilder.Entity<PermitStructure>()
            .HasKey(p => new { p.ValidFrom, p.Comment, p.PermitTypeId });

        modelBuilder.Entity<PermitStructure>()
            .OwnsOne(p => p.PermitType, b =>
            {
                b.Property(pt => pt.Id).HasColumnName("PermitTypeId");
                b.Property(pt => pt.Name).HasColumnName("PermitTypeName");
            });

        modelBuilder.Entity<VehicleInformation>()
            .HasKey(v => v.ChassisNumber);
    }
}