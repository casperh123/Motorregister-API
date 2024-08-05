using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Models;
using Type = MotorRegister.Core.Models.Type;

namespace MotorRegister.Infrastrucutre.Database;

public sealed class MotorRegisterDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<InspectionResult> InspectionResults { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<Variant> Variants { get; set; }

    public MotorRegisterDbContext(DbContextOptions<MotorRegisterDbContext> contextOptions) : base(contextOptions)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
        // Configuring owned entities

        modelBuilder.Entity<Model>()
            .HasKey(v => v.Id);

        modelBuilder.Entity<Type>()
            .HasKey(v => v.Id);

        modelBuilder.Entity<Variant>()
            .HasKey(v => v.Id);
            

        modelBuilder.Entity<VehicleInformation>()
            .OwnsOne<VehicleDesignation>(v => v.Designation);
        
        
        modelBuilder.Entity<VehicleInformation>()
            .HasKey(v => v.ChassisNumber);

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
    }
}