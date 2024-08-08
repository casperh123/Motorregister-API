using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlPermission
{
    [XmlElement(ElementName = "TilladelseStruktur")]
    public XmlPermissionDetails Details { get; set; }
}