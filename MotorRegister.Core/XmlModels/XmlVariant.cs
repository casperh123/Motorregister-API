using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlVariant
{
    [XmlElement(ElementName = "KoeretoejVariantTypeNummer")]
    public long Id { get; set; }

    [XmlElement(ElementName = "KoeretoejVariantTypeNavn")]
    public string Name { get; set; }
}