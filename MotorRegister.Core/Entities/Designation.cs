using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Designation
{
    [Key]
    public int VehicleId { get; set; }
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }
    
    [ForeignKey("Model")]
    public int ModelId { get; set; }
    public Model Model { get; set; }
    
    [ForeignKey("Variant")]
    public long VariantId { get; set; }
    public Variant Variant { get; set; }
    
    [ForeignKey("Type")]
    public long TypeId { get; set; }
    public Type Type { get; set; }
    
    public Designation() {}

    public Designation(XmlVehicleDesignation designation, int vehicleId)
    {
        VehicleId = vehicleId;
        ManufacturerId = designation.ManufacturerId;
        ManufacturerName = designation.ManufacturerName;
        ModelId = designation.XmlModel.Id;
        Model = new Model(designation.XmlModel);
        VariantId = designation.XmlVariant.Id;
        Variant = new Variant(designation.XmlVariant);
        TypeId = designation.XmlType.Id;
        Type = new Type(designation.XmlType);
    }
}