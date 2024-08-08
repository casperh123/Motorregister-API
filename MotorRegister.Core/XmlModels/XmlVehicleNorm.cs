using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlVehicleNorm
{
    [XmlElement(ElementName = "NormTypeStruktur")]
    public NormType Type { get; set; }
}