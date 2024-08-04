using System.Xml.Serialization;

namespace MotorRegister.Core.Models;


public record Variant
{
    [XmlElement(ElementName = "KoeretoejVariantTypeNummer")]
    public string Id { get; set; }

    [XmlElement(ElementName = "KoeretoejVariantTypeNavn")]
    public string Name { get; set; }
}