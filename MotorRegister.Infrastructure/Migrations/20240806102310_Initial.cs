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
                name: "VehicleInformations",
                columns: table => new
                {
                    ChassisNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedFrom = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FirstRegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    CurbWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    TechnicalTotalWeight = table.Column<long>(type: "INTEGER", nullable: false),
                    AxleCount = table.Column<short>(type: "INTEGER", nullable: false),
                    MaxAxleLoad = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TowingCapability = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    ManufacturerName = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Variant = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInformations", x => x.ChassisNumber);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Usage = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: true),
                    RegistrationNumberExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RegistrationStatus = table.Column<string>(type: "TEXT", nullable: true),
                    RegistrationStatusDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    InformationId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleInformations_InformationId",
                        column: x => x.InformationId,
                        principalTable: "VehicleInformations",
                        principalColumn: "ChassisNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Result = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VehicleId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionResults_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Permits",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permits", x => new { x.Type, x.Comment, x.ValidFrom });
                    table.ForeignKey(
                        name: "FK_Permits_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionResults_VehicleId",
                table: "InspectionResults",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permits_VehicleId",
                table: "Permits",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_InformationId",
                table: "Vehicles",
                column: "InformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionResults");

            migrationBuilder.DropTable(
                name: "Permits");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleInformations");
        }
    }
}
