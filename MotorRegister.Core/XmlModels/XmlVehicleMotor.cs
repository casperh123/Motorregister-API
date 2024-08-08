using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlVehicleMotor
{
    [XmlElement(ElementName = "KoeretoejDrivmiddelSamlingStruktur")]
    public XmlDriveAssembly XmlDriveAssembly { get; set; }
}