using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorRegister.Infrastrucutre.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleUsage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleUsage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDesignation",
                columns: table => new
                {
                    ManufacturerId = table.Column<string>(type: "TEXT", nullable: false),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    VariantId = table.Column<long>(type: "INTEGER", nullable: false),
                    TypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    ManufacturerName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDesignation", x => new { x.ManufacturerId, x.ModelId, x.TypeId, x.VariantId });
                    table.ForeignKey(
                        name: "FK_VehicleDesignation_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleDesignation_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleDesignation_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedFrom = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FirstRegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChassisNumber = table.Column<string>(type: "TEXT", nullable: false),
                    TotalWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    CurbWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    TechnicalTotalWeight = table.Column<long>(type: "INTEGER", nullable: false),
                    AxleCount = table.Column<short>(type: "INTEGER", nullable: false),
                    MaxAxleLoad = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TowingCapability = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    DesignationManufacturerId = table.Column<string>(type: "TEXT", nullable: false),
                    DesignationModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    DesignationTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    DesignationVariantId = table.Column<long>(type: "INTEGER", nullable: false),
                    VehicleDesignationManufacturerId = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleDesignationModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    VehicleDesignationTypeId = table.Column<long>(type: "INTEGER", nullable: true),
                    VehicleDesignationVariantId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleInformation_VehicleDesignation_DesignationManufacturerId_DesignationModelId_DesignationTypeId_DesignationVariantId",
                        columns: x => new { x.DesignationManufacturerId, x.DesignationModelId, x.DesignationTypeId, x.DesignationVariantId },
                        principalTable: "VehicleDesignation",
                        principalColumns: new[] { "ManufacturerId", "ModelId", "TypeId", "VariantId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleInformation_VehicleDesignation_VehicleDesignationManufacturerId_VehicleDesignationModelId_VehicleDesignationTypeId_VehicleDesignationVariantId",
                        columns: x => new { x.VehicleDesignationManufacturerId, x.VehicleDesignationModelId, x.VehicleDesignationTypeId, x.VehicleDesignationVariantId },
                        principalTable: "VehicleDesignation",
                        principalColumns: new[] { "ManufacturerId", "ModelId", "TypeId", "VariantId" });
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleTypeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    UsageId = table.Column<int>(type: "INTEGER", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationNumberExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    InformationId = table.Column<int>(type: "INTEGER", nullable: true),
                    RegistrationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationStatusDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleInformation_InformationId",
                        column: x => x.InformationId,
                        principalTable: "VehicleInformation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleUsage_UsageId",
                        column: x => x.UsageId,
                        principalTable: "VehicleUsage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InspectionResults",
                columns: table => new
                {
                    VehicleId = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Result = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionResults", x => new { x.VehicleId, x.Date });
                    table.ForeignKey(
                        name: "FK_InspectionResults_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permit",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    PermitTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permit", x => new { x.PermitTypeId, x.Comment, x.ValidFrom });
                    table.ForeignKey(
                        name: "FK_Permit_PermitType_PermitTypeId",
                        column: x => x.PermitTypeId,
                        principalTable: "PermitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permit_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permit_VehicleId",
                table: "Permit",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDesignation_ModelId",
                table: "VehicleDesignation",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDesignation_TypeId",
                table: "VehicleDesignation",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDesignation_VariantId",
                table: "VehicleDesignation",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInformation_DesignationManufacturerId_DesignationModelId_DesignationTypeId_DesignationVariantId",
                table: "VehicleInformation",
                columns: new[] { "DesignationManufacturerId", "DesignationModelId", "DesignationTypeId", "DesignationVariantId" });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInformation_VehicleDesignationManufacturerId_VehicleDesignationModelId_VehicleDesignationTypeId_VehicleDesignationVariantId",
                table: "VehicleInformation",
                columns: new[] { "VehicleDesignationManufacturerId", "VehicleDesignationModelId", "VehicleDesignationTypeId", "VehicleDesignationVariantId" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_InformationId",
                table: "Vehicles",
                column: "InformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UsageId",
                table: "Vehicles",
                column: "UsageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionResults");

            migrationBuilder.DropTable(
                name: "Permit");

            migrationBuilder.DropTable(
                name: "PermitType");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleInformation");

            migrationBuilder.DropTable(
                name: "VehicleUsage");

            migrationBuilder.DropTable(
                name: "VehicleDesignation");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
