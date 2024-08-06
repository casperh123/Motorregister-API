using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using MotorRegister.Core.Entities;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record VehicleInformation
{
    [Key]
    public string ChassisNumber { get; set; }
    public string? CreatedFrom { get; set; }
    public string? Status { get; set; }
    public DateTime StatusDate { get; set; }
    public DateTime FirstRegistrationDate { get; set; }
    public int TotalWeight { get; set; }
    public int CurbWeight { get; set; }
    public long TechnicalTotalWeight { get; set; }
    public short AxleCount { get; set; }
    public int MaxAxleLoad { get; set; }
    public int PassengerCount { get; set; }
    public bool TowingCapability { get; set; }
    public string? Comment { get; set; }
    public string ManufacturerName { get; set; }
    public string Model { get; set; }
    public string Variant { get; set; }
    public string Type { get; set; }
    
    public VehicleInformation() { }

    public VehicleInformation(XmlVehicleInformation xmlVehicleInfo)
    {
        CreatedFrom = xmlVehicleInfo.CreatedFrom;
        Status = xmlVehicleInfo.Status;
        StatusDate = xmlVehicleInfo.StatusDate ?? DateTime.MinValue;
        FirstRegistrationDate = xmlVehicleInfo.FirstRegistrationDate ?? DateTime.MinValue;
        ChassisNumber = xmlVehicleInfo.ChassisNumber;
        TotalWeight = xmlVehicleInfo.TotalWeight;
        CurbWeight = xmlVehicleInfo.CurbWeight;
        TechnicalTotalWeight = xmlVehicleInfo.TechnicalTotalWeight;
        AxleCount = xmlVehicleInfo.AxleCount;
        MaxAxleLoad = xmlVehicleInfo.MaxAxleLoad;
        PassengerCount = xmlVehicleInfo.PassengerCount;
        TowingCapability = xmlVehicleInfo.TowingCapability;
        Comment = xmlVehicleInfo.Comment;

        if (xmlVehicleInfo.Designation != null)
        {
            ManufacturerName = xmlVehicleInfo.Designation.ManufacturerName;
            Model = xmlVehicleInfo.Designation.XmlModel?.Name ?? "";
            Variant = xmlVehicleInfo.Designation.XmlVariant?.Name ?? "";
            Type = xmlVehicleInfo.Designation.XmlVariant?.Name ?? "";
        }
        else
        {
            ManufacturerName = "";
            Model = "";
            Variant = "";
            Type = "";
        }
        
    }
}