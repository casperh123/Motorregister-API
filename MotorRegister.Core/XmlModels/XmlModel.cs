using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlModel
{
    [XmlElement(ElementName = "KoeretoejModelTypeNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "KoeretoejModelTypeNavn")]
    public string Name { get; set; }
}