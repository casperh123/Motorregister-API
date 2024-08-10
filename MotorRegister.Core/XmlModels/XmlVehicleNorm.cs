using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlVehicleNorm
{
    [XmlElement(ElementName = "NormTypeStruktur")]
    public XmlNormType? Type { get; set; }
}