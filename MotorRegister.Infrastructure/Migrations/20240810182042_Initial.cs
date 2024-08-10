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
                name: "Fuel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Result = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionResults", x => new { x.Id, x.Date });
                });

            migrationBuilder.CreateTable(
                name: "Usage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VehicleTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    UsageId = table.Column<string>(type: "TEXT", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: true),
                    RegistrationNumberExpirationDate = table.Column<string>(type: "TEXT", nullable: true),
                    Information_CreatedFrom = table.Column<string>(type: "TEXT", nullable: false),
                    Information_Status = table.Column<string>(type: "TEXT", nullable: false),
                    Information_StatusDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Information_FirstRegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Information_ChassisNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Information_TotalWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    Information_CurbWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    Information_TechnicalTotalWeight = table.Column<long>(type: "INTEGER", nullable: false),
                    Information_AxleCount = table.Column<short>(type: "INTEGER", nullable: false),
                    Information_TowingCapability = table.Column<bool>(type: "INTEGER", nullable: false),
                    Information_TowingWeightWithoutBrakes = table.Column<int>(type: "INTEGER", nullable: false),
                    Information_TowingWeightWithBrakes = table.Column<int>(type: "INTEGER", nullable: false),
                    Information_TypeApprovalNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Information_Comment = table.Column<string>(type: "TEXT", nullable: true),
                    Information_Designation_ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Information_Designation_ManufacturerName = table.Column<string>(type: "TEXT", nullable: false),
                    Information_Designation_Model = table.Column<string>(type: "TEXT", nullable: false),
                    Information_Designation_Variant = table.Column<string>(type: "TEXT", nullable: false),
                    Information_Designation_Type = table.Column<string>(type: "TEXT", nullable: false),
                    Information_Color = table.Column<string>(type: "TEXT", nullable: false),
                    Information_Norm = table.Column<string>(type: "TEXT", nullable: false),
                    Information_ParticleFilter = table.Column<bool>(type: "INTEGER", nullable: false),
                    RegistrationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationStatusDate = table.Column<string>(type: "TEXT", nullable: false),
                    InspectionResultId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InspectionResultDate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_InspectionResults_InspectionResultId_InspectionResultDate",
                        columns: x => new { x.InspectionResultId, x.InspectionResultDate },
                        principalTable: "InspectionResults",
                        principalColumns: new[] { "Id", "Date" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Usage_UsageId",
                        column: x => x.UsageId,
                        principalTable: "Usage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DriveType",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    KilometersPerLitre = table.Column<float>(type: "REAL", nullable: false),
                    FuelId = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryDrive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveType", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_DriveType_Fuel_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriveType_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ValidFrom = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    PermissionType = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriveType_FuelId",
                table: "DriveType",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_VehicleId",
                table: "Permission",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_InspectionResultId_InspectionResultDate",
                table: "Vehicles",
                columns: new[] { "InspectionResultId", "InspectionResultDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UsageId",
                table: "Vehicles",
                column: "UsageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriveType");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "InspectionResults");

            migrationBuilder.DropTable(
                name: "Usage");
        }
    }
}
