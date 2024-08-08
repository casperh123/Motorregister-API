using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlPermission
{
    [XmlElement(ElementName = "TilladelseStruktur")]
    public XmlPermissionDetails Details { get; set; }
}