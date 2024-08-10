using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Designation
{
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }
    public string? ModelId { get; set; }
    public Model? Model { get; set; }
    public string? VariantId { get; set; }
    public Variant? Variant { get; set; }
    public string? TypeId { get; set; }
    public Type? Type { get; set; }
    
    public Designation() {}

    public Designation(XmlVehicleDesignation designation)
    {
        ManufacturerId = designation.ManufacturerId;
        ManufacturerName = designation.ManufacturerName;
        Model = designation.XmlModel?.Name != null && designation.XmlModel?.Name is not "UOPLYST" ? new Model(designation.XmlModel) : null;
        ModelId = Model?.Id;
        Variant = designation.XmlVariant?.Name != null && designation.XmlVariant?.Name is not "UOPLYST" ? new Variant(designation.XmlVariant) : null;
        VariantId = Variant?.Id;
        Type = designation.XmlType?.Name != null && designation.XmlType?.Name is not "UOPLYST" ? new Type(designation.XmlType) : null;
        TypeId = Type?.Id;
    }
}