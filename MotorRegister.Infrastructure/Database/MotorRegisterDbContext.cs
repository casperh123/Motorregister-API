using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Infrastrucutre.Database;

public sealed class MotorRegisterDbContext : DbContext
{
    public DbSet<XmlVehicle> Vehicles { get; set; }
    public DbSet<XmlInspectionResult> InspectionResults { get; set; }
    public DbSet<XmlModel> Models { get; set; }
    public DbSet<XmlType> Types { get; set; }
    public DbSet<XmlVariant> Variants { get; set; }

    public MotorRegisterDbContext(DbContextOptions<MotorRegisterDbContext> contextOptions) : base(contextOptions)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
        // Configuring owned entities

        modelBuilder.Entity<XmlModel>()
            .HasKey(v => v.Id);

        modelBuilder.Entity<XmlType>()
            .HasKey(v => v.Id);

        modelBuilder.Entity<XmlVariant>()
            .HasKey(v => v.Id);
            

        modelBuilder.Entity<XmlVehicleInformation>()
            .OwnsOne<XmlVehicleDesignation>(v => v.Designation);
        
        
        modelBuilder.Entity<XmlVehicleInformation>()
            .HasKey(v => v.ChassisNumber);

        modelBuilder.Entity<XmlInspectionResult>()
            .HasKey(v => new { v.VehicleId, v.Date });
        
        modelBuilder.Entity<XmlPermitStructure>()
            .HasKey(p => new { p.ValidFrom, p.Comment, p.PermitTypeId });

        modelBuilder.Entity<XmlPermitStructure>()
            .OwnsOne(p => p.XmlPermitType, b =>
            {
                b.Property(pt => pt.Id).HasColumnName("PermitTypeId");
                b.Property(pt => pt.Name).HasColumnName("PermitTypeName");
            });
    }
}