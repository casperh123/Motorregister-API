using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlType
{
    [XmlElement(ElementName = "KoeretoejTypeTypeNummer")]
    public long Id { get; set; }

    [XmlElement(ElementName = "KoeretoejTypeTypeNavn")]
    public string Name { get; set; }
}