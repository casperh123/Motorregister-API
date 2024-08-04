using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record Type
{
    [XmlElement(ElementName = "KoeretoejTypeTypeNummer")]
    public string Id { get; set; }

    [XmlElement(ElementName = "KoeretoejTypeTypeNavn")]
    public string Name { get; set; }
}