using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class KoeretoejAnvendelseStruktur
{
    [XmlElement(ElementName = "KoeretoejAnvendelseNummer")]
    public string KoeretoejAnvendelseNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejAnvendelseNavn")]
    public string KoeretoejAnvendelseNavn { get; set; }
}