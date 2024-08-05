using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

[XmlRoot(ElementName = "KoeretoejAnvendelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record XmlVehicleUsage
{
    [XmlElement(ElementName = "KoeretoejAnvendelseNummer")]
    public int Id { get; set; }

    [XmlElement(ElementName = "KoeretoejAnvendelseNavn")]
    public string Name { get; set; }
}