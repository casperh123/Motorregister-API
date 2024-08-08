using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlNormType
{
    [XmlElement(ElementName = "NormTypeNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "NormTypeNavn")]
    public string Name { get; set; }
}