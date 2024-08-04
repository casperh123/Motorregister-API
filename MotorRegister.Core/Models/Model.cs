using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record Model
{
    [XmlElement(ElementName = "KoeretoejModelTypeNummer")]
    public string Id { get; set; }

    [XmlElement(ElementName = "KoeretoejModelTypeNavn")]
    public string Name { get; set; }
}