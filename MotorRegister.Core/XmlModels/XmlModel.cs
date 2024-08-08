using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlModel
{
    [XmlElement(ElementName = "KoeretoejModelTypeNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "KoeretoejModelTypeNavn")]
    public string Name { get; set; }
}