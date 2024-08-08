using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class xmlDrivePowerType
{
    [XmlElement(ElementName = "DrivkraftTypeNummer")]
    public long Id { get; set; }

    [XmlElement(ElementName = "DrivkraftTypeNavn")]
    public string Name { get; set; }
}