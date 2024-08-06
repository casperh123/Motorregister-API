using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record VehicleInformation
{
    [Key]
    public string ChassisNumber { get; set; }
    public string? CreatedFrom { get; set; }
    public DateTime StatusDate { get; set; }
    public DateTime FirstRegistrationDate { get; set; }
    public bool TowingCapability { get; set; }
    
    public VehicleInformation() { }

    public VehicleInformation(XmlVehicleInformation xmlVehicleInfo)
    {
        CreatedFrom = xmlVehicleInfo.CreatedFrom;
        StatusDate = xmlVehicleInfo.StatusDate ?? DateTime.MinValue;
        FirstRegistrationDate = xmlVehicleInfo.FirstRegistrationDate ?? DateTime.MinValue;
        ChassisNumber = xmlVehicleInfo.ChassisNumber;
        TowingCapability = xmlVehicleInfo.TowingCapability;
    }
}