using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MotorRegister.Core.Api;
using MotorRegister.Core.DataTransferObjects;
using MotorRegister.Core.Entities;

namespace MotorRegister.Api;

public record VehicleDTO
{
    public string VehicleTypeName { get; set; }
    public string Usage { get; set; }
    public string RegistrationNumber { get; set; }
    public string RegistrationNumberExpirationDate { get; set; }
    public InformationDTO Information { get; set; }
    public DesignationDTO Designation { get; set; }
    public string RegistrationStatus { get; set; }   
    public string RegistrationStatusDate { get; set; }
    public InspectionResultDTO InspectionResult { get; set; }
    public PermissionDTO Permission { get; set; }
    public EngineDetailsDTO EngineDetails { get; set; }
    public bool ParticleFilter { get; set; }

    public VehicleDTO(Vehicle vehicle)
    {
        VehicleTypeName = vehicle.VehicleTypeName;
        Usage = vehicle.Usage?.Name ?? "";
        RegistrationNumber = vehicle.RegistrationNumber ?? "";
        RegistrationNumberExpirationDate = vehicle.RegistrationNumberExpirationDate ?? "";
        Information = new InformationDTO(vehicle.Information);
        Designation = new DesignationDTO(vehicle.Information.Designation);
        RegistrationStatus = vehicle.RegistrationStatus ?? "";
        RegistrationStatusDate = vehicle.RegistrationStatusDate ?? "";
        InspectionResult = vehicle.InspectionResult != null ? new InspectionResultDTO(vehicle.InspectionResult) : new InspectionResultDTO();
        Permission = new PermissionDTO(vehicle.Permissions.FirstOrDefault(new Permission()));
        EngineDetails = new EngineDetailsDTO(vehicle.DriveType);
        ParticleFilter = Information.ParticleFilter;
    }
}