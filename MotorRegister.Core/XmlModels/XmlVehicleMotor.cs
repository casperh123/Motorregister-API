using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlVehicleMotor
{
    [XmlElement(ElementName = "KoeretoejDrivmiddelSamlingStruktur")]
    public XmlDriveAssembly XmlDriveAssembly { get; set; }
}