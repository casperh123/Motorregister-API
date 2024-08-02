using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class Type
{
    [XmlElement(ElementName = "KoeretoejTypeTypeNummer")]
    public string KoeretoejTypeTypeNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejTypeTypeNavn")]
    public string KoeretoejTypeTypeNavn { get; set; }
}