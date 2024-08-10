using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlPermissionType
{
    [XmlElement(ElementName = "TilladelseTypeNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "TilladelseTypeNavn")]
    public string Name { get; set; }
}