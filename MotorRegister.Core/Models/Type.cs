using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record Type
{
    [XmlElement(ElementName = "KoeretoejTypeTypeNummer")]
    public string KoeretoejTypeTypeNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejTypeTypeNavn")]
    public string KoeretoejTypeTypeNavn { get; set; }
}