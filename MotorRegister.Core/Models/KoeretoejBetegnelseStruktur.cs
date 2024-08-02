using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class KoeretoejBetegnelseStruktur
{
    [XmlElement(ElementName = "KoeretoejMaerkeTypeNummer")]
    public string KoeretoejMaerkeTypeNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejMaerkeTypeNavn")]
    public string KoeretoejMaerkeTypeNavn { get; set; }

    [XmlElement(ElementName = "Model")]
    public Model Model { get; set; }

    [XmlElement(ElementName = "Variant")]
    public Variant Variant { get; set; }

    [XmlElement(ElementName = "Type")]
    public Type Type { get; set; }
}