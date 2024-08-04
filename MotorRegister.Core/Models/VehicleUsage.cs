using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "KoeretoejAnvendelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record VehicleUsage
{
    [XmlElement(ElementName = "KoeretoejAnvendelseNummer")]
    public string Id { get; set; }

    [XmlElement(ElementName = "KoeretoejAnvendelseNavn")]
    public string Name { get; set; }
}