using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Vehicle
{
    public long Id { get; set; }
    public long VehicleTypeNumber { get; set; }
    public string VehicleTypeName { get; set; }
    
    //[ForeignKey("Usage")]
    //public long UsageId { get; set; }
    //public Usage Usage { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? RegistrationNumberExpirationDate { get; set; }
    public Information Information { get; set; }
    public string RegistrationStatus { get; set; }
    public string RegistrationStatusDate { get; set; }
    //public List<InspectionResult> InspectionResults { get; set; }
    //public List<Permission> Permissions { get; set; }
    //public List<DriveType> DriveTypes { get; set; }

    
    public Vehicle() {}

    public Vehicle(XmlVehicle vehicle)
    {
        Id = vehicle.Id;
        VehicleTypeNumber = vehicle.VehicleTypeNumber;
        VehicleTypeName = vehicle.VehicleTypeName;
        //UsageId = vehicle.Usage.Id;
        //Usage = new Usage(vehicle.Usage);
        RegistrationNumber = vehicle.RegistrationNumber;
        RegistrationNumberExpirationDate = vehicle.RegistrationNumberExpirationDate;
        Information = new Information(vehicle.Information);
        RegistrationStatus = vehicle.RegistrationStatus;
        RegistrationStatusDate = vehicle.RegistrationStatusDate;
/*
        InspectionResults = [];
        Permissions = [];
        
        foreach (XmlInspectionResult inspectionResult in vehicle.InspectionResults)
        {
            InspectionResults.Add(new InspectionResult(inspectionResult, Id));
        }

        foreach (XmlPermission permission in vehicle.Permissions)
        {
            if (permission != null)
            {
                Permissions.Add(new Permission(permission, Id));    
            }
        }
        
        DriveTypes = [];

        if (vehicle.Information.Motor != null && vehicle.Information.Motor.XmlDriveAssembly != null && vehicle.Information.Motor.XmlDriveAssembly.Drives != null)
        {
            foreach (XmlDrive driveType in vehicle.Information.Motor.XmlDriveAssembly.Drives)
            {
                if (driveType.Type != null)
                {
                    DriveTypes.Add(new DriveType(driveType.Type));
                }
            }
        }*/
    }
}