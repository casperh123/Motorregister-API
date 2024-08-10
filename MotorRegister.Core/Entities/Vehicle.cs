using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;

namespace MotorRegister.Core.Entities;

public record Vehicle
{
    public Guid Id { get; set; }
    public string VehicleTypeName { get; set; }
    public string? UsageId { get; set; }
    public Usage? Usage { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? RegistrationNumberExpirationDate { get; set; }
    public Information Information { get; set; }
    public string RegistrationStatus { get; set; }
    public string RegistrationStatusDate { get; set; }
    public InspectionResult InspectionResult { get; set; }
    public List<Permission> Permissions { get; set; }
    public DriveType DriveType { get; set; }

    
    public Vehicle() {}

    public Vehicle(XmlVehicle vehicle)
    {
        Id = GuidParser.ConvertLongToGuid(vehicle.Id);
        VehicleTypeName = vehicle.VehicleTypeName;
        Usage = vehicle.Usage != null ? new Usage(vehicle.Usage) : null;
        UsageId = Usage.Id;
        RegistrationNumber = vehicle.RegistrationNumber;
        RegistrationNumberExpirationDate = vehicle.RegistrationNumberExpirationDate;
        Information = new Information(vehicle.Information);
        RegistrationStatus = vehicle.RegistrationStatus;
        RegistrationStatusDate = vehicle.RegistrationStatusDate;
        DriveType = vehicle.Information?.Motor?.XmlDriveAssembly?.Drive != null ? new DriveType(vehicle.Information?.Motor?.XmlDriveAssembly?.Drive, Id) : null;
        InspectionResult = new InspectionResult(vehicle.InspectionResult, Id);
        
        Permissions = [];


        Permissions.AddRange(
            vehicle.Permissions
                .Where(permission => permission?.Details != null)
                .Select(permission => new Permission(permission, Id))
        );
        

    }
}