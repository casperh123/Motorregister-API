using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public record XmlModel
{
    [XmlElement(ElementName = "KoeretoejModelTypeNavn")]
    public string Name { get; set; }
}