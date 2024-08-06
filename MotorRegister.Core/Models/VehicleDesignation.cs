using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record VehicleDesignation
{
    public string ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; }
    public long VariantId { get; set; } 
    public Variant Variant { get; set; }
    public long TypeId { get; set; }
    public VehicleType VehicleType { get; set; }

    public VehicleDesignation() { }
    
    public VehicleDesignation(XmlVehicleDesignation xmlDesignation)
    {
        ManufacturerId = xmlDesignation.ManufacturerId;
        ManufacturerName = xmlDesignation.ManufacturerName;
        Model = new Model(xmlDesignation.XmlModel);
        Variant = new Variant(xmlDesignation.XmlVariant);
        VehicleType = new VehicleType(xmlDesignation.XmlType);
        
        if (xmlDesignation.XmlModel != null)
        {
            Model = new Model(xmlDesignation.XmlModel);
            ModelId = Model.Id;
        }

        if (xmlDesignation.XmlVariant != null)
        {
            Variant = new Variant(xmlDesignation.XmlVariant);
            VariantId = Variant.Id;
        }

        if (xmlDesignation.XmlType != null)
        {
            VehicleType = new VehicleType(xmlDesignation.XmlType);
            TypeId = VehicleType.Id;
        }
    }
}