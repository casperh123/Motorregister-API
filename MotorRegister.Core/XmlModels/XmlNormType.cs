using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlNormType
{
    [XmlElement(ElementName = "NormTypeNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "NormTypeNavn")]
    public string Name { get; set; }
}