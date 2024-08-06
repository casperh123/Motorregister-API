using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;


public record XmlVariant
{
    [XmlElement(ElementName = "KoeretoejVariantTypeNavn")]
    public string? Name { get; set; }
}