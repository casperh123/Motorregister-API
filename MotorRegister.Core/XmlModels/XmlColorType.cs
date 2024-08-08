using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlColorType
{
    [XmlElement(ElementName = "FarveTypeNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "FarveTypeNavn")]
    public string Name { get; set; }
}