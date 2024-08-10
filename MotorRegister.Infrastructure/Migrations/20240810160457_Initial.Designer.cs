﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorRegister.Infrastrucutre.Database;

#nullable disable

namespace MotorRegister.Infrastrucutre.Migrations
{
    [DbContext(typeof(MotorRegisterDbContext))]
    [Migration("20240810160457_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4");

            modelBuilder.Entity("MotorRegister.Core.Entities.DriveType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("PrimaryDrive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("DriveType");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.InspectionResult", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id", "Date");

                    b.HasIndex("VehicleId");

                    b.ToTable("InspectionResults");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PermissionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ValidFrom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.Usage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usage");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationNumberExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationStatusDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UsageId")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UsageId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.DriveType", b =>
                {
                    b.HasOne("MotorRegister.Core.Entities.Vehicle", null)
                        .WithMany("DriveTypes")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.InspectionResult", b =>
                {
                    b.HasOne("MotorRegister.Core.Entities.Vehicle", null)
                        .WithMany("InspectionResults")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.Permission", b =>
                {
                    b.HasOne("MotorRegister.Core.Entities.Vehicle", null)
                        .WithMany("Permissions")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.Vehicle", b =>
                {
                    b.HasOne("MotorRegister.Core.Entities.Usage", "Usage")
                        .WithMany()
                        .HasForeignKey("UsageId");

                    b.OwnsOne("MotorRegister.Core.Entities.Information", "Information", b1 =>
                        {
                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("TEXT");

                            b1.Property<short>("AxleCount")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ChassisNumber")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Color")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Comment")
                                .HasColumnType("TEXT");

                            b1.Property<string>("CreatedFrom")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("CurbWeight")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime?>("FirstRegistrationDate")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Norm")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<bool>("ParticleFilter")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("StatusDate")
                                .HasColumnType("TEXT");

                            b1.Property<long>("TechnicalTotalWeight")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("TotalWeight")
                                .HasColumnType("INTEGER");

                            b1.Property<bool>("TowingCapability")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("TowingWeightWithBrakes")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("TowingWeightWithoutBrakes")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("TypeApprovalNumber")
                                .HasColumnType("TEXT");

                            b1.HasKey("VehicleId");

                            b1.ToTable("Vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId");

                            b1.OwnsOne("MotorRegister.Core.Entities.Designation", "Designation", b2 =>
                                {
                                    b2.Property<Guid>("InformationVehicleId")
                                        .HasColumnType("TEXT");

                                    b2.Property<int>("ManufacturerId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("ManufacturerName")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Model")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Type")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Variant")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.HasKey("InformationVehicleId");

                                    b2.ToTable("Vehicles");

                                    b2.WithOwner()
                                        .HasForeignKey("InformationVehicleId");
                                });

                            b1.Navigation("Designation")
                                .IsRequired();
                        });

                    b.Navigation("Information")
                        .IsRequired();

                    b.Navigation("Usage");
                });

            modelBuilder.Entity("MotorRegister.Core.Entities.Vehicle", b =>
                {
                    b.Navigation("DriveTypes");

                    b.Navigation("InspectionResults");

                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
