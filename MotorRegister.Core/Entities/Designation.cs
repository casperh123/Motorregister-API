using System.Xml;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Designation
{
    public int VehicleId { get; set; }
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }
    public Model Model { get; set; }
    public Variant Variant { get; set; }
    public Type Type { get; set; }
    
    public Designation() {}

    public Designation(XmlVehicleDesignation designation, int vehicleId)
    {
        VehicleId = vehicleId;
        ManufacturerId = designation.ManufacturerId;
        ManufacturerName = designation.ManufacturerName;
        Model = new Model(designation.XmlModel);
        Variant = new Variant(designation.XmlVariant);
        Type = new Type(designation.XmlType);
    }
}