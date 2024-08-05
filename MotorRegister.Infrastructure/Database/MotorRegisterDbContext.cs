using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Models;

namespace MotorRegister.Infrastrucutre.Database;

public sealed class MotorRegisterDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<InspectionResult> InspectionResults { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<VehicleType> Types { get; set; }
    public DbSet<Variant> Variants { get; set; }

    public MotorRegisterDbContext(DbContextOptions<MotorRegisterDbContext> contextOptions) : base(contextOptions)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InspectionResult>()
            .HasKey(i => new { i.VehicleId, i.Date });

        modelBuilder.Entity<Permit>()
            .HasKey(p => new {p.PermitTypeId, p.Comment, p.ValidFrom});

        modelBuilder.Entity<VehicleInformation>()
            .HasOne<VehicleDesignation>();

        modelBuilder.Entity<VehicleDesignation>(v =>
        {
            v.HasKey(vd => new { vd.ManufacturerId, vd.ModelId, vd.TypeId, vd.VariantId });
        
            v.HasOne(vd => vd.Model)
                .WithMany()
                .HasForeignKey(vd => vd.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            v.HasOne(vd => vd.Variant)
                .WithMany()
                .HasForeignKey(vd => vd.VariantId)
                .OnDelete(DeleteBehavior.Restrict);

            v.HasOne(vd => vd.VehicleType)
                .WithMany()
                .HasForeignKey(vd => vd.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Model>(m =>
        {
            m.HasKey(md => md.Id);
            m.HasMany<VehicleDesignation>()
                .WithOne(vd => vd.Model)
                .HasForeignKey(vd => vd.ModelId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Variant>(v =>
        {
            v.HasKey(va => va.Id);
            v.HasMany<VehicleDesignation>()
                .WithOne(vd => vd.Variant)
                .HasForeignKey(vd => vd.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<VehicleType>(vt =>
        {
            vt.HasKey(t => t.Id);
            vt.HasMany<VehicleDesignation>()
                .WithOne(vd => vd.VehicleType)
                .HasForeignKey(vd => vd.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
        });

    }
}