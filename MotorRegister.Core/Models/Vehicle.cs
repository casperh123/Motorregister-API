using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "Statistik", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record Vehicle
{
    [XmlElement(ElementName = "KoeretoejIdent")]
    public string KoeretoejIdent { get; set; }

    [XmlElement(ElementName = "KoeretoejArtNummer")]
    public int KoeretoejArtNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejArtNavn")]
    public string KoeretoejArtNavn { get; set; }

    [XmlElement(ElementName = "KoeretoejAnvendelseStruktur")]
    public KoeretoejAnvendelseStruktur KoeretoejAnvendelseStruktur { get; set; }

    [XmlElement(ElementName = "RegistreringNummerNummer")]
    public string RegistreringNummerNummer { get; set; }

    [XmlElement(ElementName = "RegistreringNummerUdloebDato")]
    public string RegistreringNummerUdloebDato { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningGrundStruktur")]
    public KoeretoejOplysningGrundStruktur KoeretoejOplysningGrundStruktur { get; set; }

    [XmlElement(ElementName = "SynResultatStruktur")]
    public SynResultatStruktur SynResultatStruktur { get; set; }

    [XmlElement(ElementName = "KoeretoejRegistreringStatus")]
    public string KoeretoejRegistreringStatus { get; set; }

    [XmlElement(ElementName = "KoeretoejRegistreringStatusDato")]
    public string KoeretoejRegistreringStatusDato { get; set; }

    [XmlElement(ElementName = "TilladelseSamling")]
    public List<Tilladelse> TilladelseSamling { get; set; }
}