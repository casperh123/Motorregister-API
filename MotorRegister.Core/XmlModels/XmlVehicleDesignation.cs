using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

[XmlRoot(ElementName = "KoeretoejBetegnelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record XmlVehicleDesignation
{
    [XmlElement(ElementName = "KoeretoejMaerkeTypeNavn")]
    public string ManufacturerName { get; set; }

    [XmlElement(ElementName = "Model")]
    public XmlModel XmlModel { get; set; }

    [XmlElement(ElementName = "Variant")]
    public XmlVariant XmlVariant { get; set; }
}