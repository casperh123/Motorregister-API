using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "KoeretoejBetegnelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record VehicleDesignation
{
    [XmlElement(ElementName = "KoeretoejMaerkeTypeNummer")]
    public string ManufacturerId { get; set; }

    [XmlElement(ElementName = "KoeretoejMaerkeTypeNavn")]
    public string ManufacturerName { get; set; }

    [XmlElement(ElementName = "Model")]
    public Model Model { get; set; }

    [XmlElement(ElementName = "Variant")]
    public Variant Variant { get; set; }

    [XmlElement(ElementName = "Type")]
    public Type Type { get; set; }
}