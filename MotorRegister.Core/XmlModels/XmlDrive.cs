using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlDrive
{
    [XmlElement(ElementName = "DrivmiddelStruktur")]
    public XmlDriveType Type { get; set; }
}