using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlVehicleColor
{
    [XmlElement(ElementName = "FarveTypeStruktur")]
    public XmlColorType Type { get; set; }
}