using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Make
{
    [Key]
    public string Id { get; set; }
    public string ManufacturerName { get; set; }
    public string Model { get; set; }
    public string Variant { get; set; }
    public int TotalWeight { get; set; }
    public int CurbWeight { get; set; }
    public long TechnicalTotalWeight { get; set; }
    public short AxleCount { get; set; }
    public int MaxAxleLoad { get; set; }
    public int PassengerCount { get; set; }
    
    public Make() {}

    public Make(XmlVehicleInformation information)
    {
        TotalWeight = information.TotalWeight;
        CurbWeight = information.CurbWeight;
        TechnicalTotalWeight = information.TechnicalTotalWeight;
        AxleCount = information.AxleCount;
        MaxAxleLoad = information.MaxAxleLoad;
        PassengerCount = information.PassengerCount;
        
        if (information.Designation != null)
        {
            ManufacturerName = information.Designation.ManufacturerName;
            Model = information.Designation.XmlModel?.Name ?? "";
            Variant = information.Designation.XmlVariant?.Name ?? "";
        }
        else
        {
            ManufacturerName = "";
            Model = "";
            Variant = "";
        }
    }
}