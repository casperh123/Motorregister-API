using System.Xml.Serialization;

namespace MotorRegister.Core.Models;


public class XmlDriveType
{
    [XmlElement(ElementName = "DrivkraftTypeStruktur")]
    public xmlDrivePowerType Type { get; set; }

    [XmlElement(ElementName = "KoeretoejMotorDrivmiddelPrimaer")]
    public bool PrimaryDrive { get; set; }
}