using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;

namespace MotorRegister.Core.Entities;

public record Vehicle
{
    public Guid Id { get; set; }
    public string VehicleTypeName { get; set; }
    public Guid? UsageId { get; set; }
    public Usage? Usage { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? RegistrationNumberExpirationDate { get; set; }
    public Information Information { get; set; }
    public string RegistrationStatus { get; set; }
    public string RegistrationStatusDate { get; set; }
    public List<InspectionResult> InspectionResults { get; set; }
    public List<Permission> Permissions { get; set; }
    public List<DriveType> DriveTypes { get; set; }

    
    public Vehicle() {}

    public Vehicle(XmlVehicle vehicle)
    {
        Id = GuidParser.ConvertLongToGuid(vehicle.Id);
        VehicleTypeName = vehicle.VehicleTypeName;
        Usage = new Usage(vehicle.Usage);
        UsageId = Usage.Id;
        RegistrationNumber = vehicle.RegistrationNumber;
        RegistrationNumberExpirationDate = vehicle.RegistrationNumberExpirationDate;
        Information = new Information(vehicle.Information);
        RegistrationStatus = vehicle.RegistrationStatus;
        RegistrationStatusDate = vehicle.RegistrationStatusDate;

        InspectionResults = [];
        Permissions = [];
        DriveTypes = [];

        
        InspectionResults.AddRange(vehicle.InspectionResults.Select(inspectionResult => new InspectionResult(inspectionResult, Id)));

        Permissions.AddRange(
            vehicle.Permissions
                .Where(permission => permission?.Details != null)
                .Select(permission => new Permission(permission, Id))
        );

        
        if (vehicle.Information?.Motor?.XmlDriveAssembly?.Drives != null)
        {
            DriveTypes.AddRange(vehicle.Information.Motor.XmlDriveAssembly.Drives
                .Where(driveType => driveType.Type != null)
                .Select(driveType => new DriveType(driveType.Type)));
        }

    }
}