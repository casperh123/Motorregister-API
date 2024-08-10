using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;


public class XmlDriveType
{
    [XmlElement(ElementName = "DrivkraftTypeStruktur")]
    public xmlDrivePowerType Type { get; set; }
    
    [XmlElement(ElementName = "KoeretoejBraendstofStruktur")]
    public XmlFuelStructure Fuel { get; set; }

    [XmlElement(ElementName = "KoeretoejMotorDrivmiddelPrimaer")]
    public bool PrimaryDrive { get; set; }
}