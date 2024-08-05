using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public record XmlType
{
    [XmlElement(ElementName = "KoeretoejTypeTypeNummer")]
    public string Id { get; set; }

    [XmlElement(ElementName = "KoeretoejTypeTypeNavn")]
    public string Name { get; set; }
}