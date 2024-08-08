using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlDrive
{
    [XmlElement(ElementName = "DrivmiddelStruktur")]
    public DriveType Type { get; set; }
}