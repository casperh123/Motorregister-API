using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlVehicleUsage
{
    [XmlElement(ElementName = "KoeretoejAnvendelseNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "KoeretoejAnvendelseNavn")]
    public string Name { get; set; }
}