
using System.Xml.Serialization;

public class Statistik
{
    [XmlElement(ElementName = "KoeretoejIdent")]
    public string KoeretoejIdent { get; set; }

    [XmlElement(ElementName = "KoeretoejArtNummer")]
    public string KoeretoejArtNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejArtNavn")]
    public string KoeretoejArtNavn { get; set; }

    [XmlElement(ElementName = "KoeretoejAnvendelseStruktur")]
    public KoeretoejAnvendelseStruktur KoeretoejAnvendelseStruktur { get; set; }

    [XmlElement(ElementName = "RegistreringNummerNummer")]
    public string RegistreringNummerNummer { get; set; }

    [XmlElement(ElementName = "RegistreringNummerUdloebDato")]
    public DateTime RegistreringNummerUdloebDato { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningGrundStruktur")]
    public KoeretoejOplysningGrundStruktur KoeretoejOplysningGrundStruktur { get; set; }

    [XmlElement(ElementName = "SynResultatStruktur")]
    public SynResultatStruktur SynResultatStruktur { get; set; }

    [XmlElement(ElementName = "KoeretoejRegistreringStatus")]
    public string KoeretoejRegistreringStatus { get; set; }

    [XmlElement(ElementName = "KoeretoejRegistreringStatusDato")]
    public DateTime KoeretoejRegistreringStatusDato { get; set; }

    [XmlElement(ElementName = "TilladelseSamling")]
    public TilladelseSamling TilladelseSamling { get; set; }
}