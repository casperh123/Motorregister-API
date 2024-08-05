using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;


public record XmlVariant
{
    [XmlElement(ElementName = "KoeretoejVariantTypeNummer")]
    public string Id { get; set; }

    [XmlElement(ElementName = "KoeretoejVariantTypeNavn")]
    public string Name { get; set; }
}