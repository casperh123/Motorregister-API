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
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
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
                    Id = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "VehicleInformation",
                columns: table => new
                {
                    ChassisNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedFrom = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDate = table.Column<string>(type: "TEXT", nullable: false),
                    FirstRegistrationDate = table.Column<string>(type: "TEXT", nullable: false),
                    TotalWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    CurbWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    TechnicalTotalWeight = table.Column<long>(type: "INTEGER", nullable: false),
                    AxleCount = table.Column<short>(type: "INTEGER", nullable: false),
                    MaxAxleLoad = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TowingCapability = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Designation_ManufacturerId = table.Column<string>(type: "TEXT", nullable: false),
                    Designation_ManufacturerName = table.Column<string>(type: "TEXT", nullable: false),
                    Designation_ModelId = table.Column<string>(type: "TEXT", nullable: false),
                    Designation_VariantId = table.Column<string>(type: "TEXT", nullable: false),
                    Designation_TypeId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInformation", x => x.ChassisNumber);
                    table.ForeignKey(
                        name: "FK_VehicleInformation_Models_Designation_ModelId",
                        column: x => x.Designation_ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleInformation_Types_Designation_TypeId",
                        column: x => x.Designation_TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleInformation_Variants_Designation_VariantId",
                        column: x => x.Designation_VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleTypeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    UsageId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationNumberExpirationDate = table.Column<string>(type: "TEXT", nullable: true, defaultValue: ""),
                    InformationChassisNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationStatusDate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleInformation_InformationChassisNumber",
                        column: x => x.InformationChassisNumber,
                        principalTable: "VehicleInformation",
                        principalColumn: "ChassisNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleUsage_UsageId",
                        column: x => x.UsageId,
                        principalTable: "VehicleUsage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionResults",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Result = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDate = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleId1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionResults", x => new { x.VehicleId, x.Date });
                    table.ForeignKey(
                        name: "FK_InspectionResults_Vehicles_VehicleId1",
                        column: x => x.VehicleId1,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PermitStructure",
                columns: table => new
                {
                    ValidFrom = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    PermitStructure_PermitTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    PermitStructure_PermitTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    PermitTypeId = table.Column<string>(type: "TEXT", nullable: true),
                    PermitTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitStructure", x => new { x.ValidFrom, x.Comment, x.PermitStructure_PermitTypeId });
                    table.ForeignKey(
                        name: "FK_PermitStructure_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionResults_VehicleId1",
                table: "InspectionResults",
                column: "VehicleId1");

            migrationBuilder.CreateIndex(
                name: "IX_PermitStructure_VehicleId",
                table: "PermitStructure",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInformation_Designation_ModelId",
                table: "VehicleInformation",
                column: "Designation_ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInformation_Designation_TypeId",
                table: "VehicleInformation",
                column: "Designation_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInformation_Designation_VariantId",
                table: "VehicleInformation",
                column: "Designation_VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_InformationChassisNumber",
                table: "Vehicles",
                column: "InformationChassisNumber");

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
                name: "PermitStructure");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleInformation");

            migrationBuilder.DropTable(
                name: "VehicleUsage");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
