using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public record XmlModel
{
    [XmlElement(ElementName = "KoeretoejModelTypeNummer")]
    public string Id { get; set; }

    [XmlElement(ElementName = "KoeretoejModelTypeNavn")]
    public string Name { get; set; }
}