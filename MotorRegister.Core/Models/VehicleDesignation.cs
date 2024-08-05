using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "KoeretoejBetegnelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record VehicleDesignation
{
    [XmlElement(ElementName = "KoeretoejMaerkeTypeNummer")]
    public string ManufacturerId { get; set; }

    [XmlElement(ElementName = "KoeretoejMaerkeTypeNavn")]
    public string ManufacturerName { get; set; }

    [XmlIgnore]
    public string ModelId
    {
        get => Model?.Id;
        set
        {
            if (Model != null)
            {
                Model.Id = value;
            }
        }
    }

    [XmlIgnore]
    public string VariantId
    {
        get => Variant?.Id;
        set
        {
            if (Variant != null)
            {
                Variant.Id = value;
            }
        }
    }

    [XmlIgnore]
    public string TypeId
    {
        get => Type?.Id;
        set
        {
            if (Type != null)
            {
                Type.Id = value;
            }
        }
    }

    [XmlElement(ElementName = "Model")]
    public Model Model { get; set; }

    [XmlElement(ElementName = "Variant")]
    public Variant Variant { get; set; }

    [XmlElement(ElementName = "Type")]
    public Type Type { get; set; }
}