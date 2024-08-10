using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Designation
{
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }
    public string Model { get; set; }
    public string Variant { get; set; }
    public string Type { get; set; }
    
    public Designation() {}

    public Designation(XmlVehicleDesignation designation)
    {
        ManufacturerId = designation.ManufacturerId;
        ManufacturerName = designation.ManufacturerName;
        Model = designation.XmlModel.Name;
        Variant = designation.XmlVariant.Name;
        Type = designation.XmlType.Name;
    }
}