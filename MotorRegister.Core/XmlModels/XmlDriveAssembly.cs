using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlDriveAssembly
{
    [XmlElement(ElementName = "KoeretoejDrivmiddelSamling")]
    public List<XmlDrive> Drives { get; set; }
}