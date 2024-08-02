using System.Xml.Serialization;

namespace MotorRegister.Core.Models;


public record Variant
{
    [XmlElement(ElementName = "KoeretoejVariantTypeNummer")]
    public string KoeretoejVariantTypeNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejVariantTypeNavn")]
    public string KoeretoejVariantTypeNavn { get; set; }
}