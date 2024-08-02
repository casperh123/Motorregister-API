using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class Model
{
    [XmlElement(ElementName = "KoeretoejModelTypeNummer")]
    public string KoeretoejModelTypeNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejModelTypeNavn")]
    public string KoeretoejModelTypeNavn { get; set; }
}