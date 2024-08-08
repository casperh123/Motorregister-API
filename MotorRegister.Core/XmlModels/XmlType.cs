using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlType
{
    [XmlElement(ElementName = "KoeretoejTypeTypeNummer")]
    public long Id { get; set; }

    [XmlElement(ElementName = "KoeretoejTypeTypeNavn")]
    public string Name { get; set; }
}