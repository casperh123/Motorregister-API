using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlVehicleColor
{
    [XmlElement(ElementName = "FarveTypeStruktur")]
    public XmlColorType? Type { get; set; }
}