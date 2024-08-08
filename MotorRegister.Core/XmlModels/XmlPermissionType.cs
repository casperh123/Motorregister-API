using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlPermissionType
{
    [XmlElement(ElementName = "TilladelseTypeNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "TilladelseTypeNavn")]
    public string Name { get; set; }
}