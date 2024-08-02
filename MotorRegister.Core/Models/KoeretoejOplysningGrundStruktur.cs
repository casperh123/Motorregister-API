using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class KoeretoejOplysningGrundStruktur
{
    [XmlElement(ElementName = "KoeretoejOplysningOprettetUdFra")]
    public string KoeretoejOplysningOprettetUdFra { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStatus")]
    public string KoeretoejOplysningStatus { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStatusDato")]
    public DateTime KoeretoejOplysningStatusDato { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningFoersteRegistreringDato")]
    public DateTime KoeretoejOplysningFoersteRegistreringDato { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStelNummer")]
    public string KoeretoejOplysningStelNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTotalVaegt")]
    public int KoeretoejOplysningTotalVaegt { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningEgenVaegt")]
    public int KoeretoejOplysningEgenVaegt { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTekniskTotalVaegt")]
    public int KoeretoejOplysningTekniskTotalVaegt { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningAkselAntal")]
    public int KoeretoejOplysningAkselAntal { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStoersteAkselTryk")]
    public int KoeretoejOplysningStoersteAkselTryk { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningPassagerAntal")]
    public int KoeretoejOplysningPassagerAntal { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTilkoblingMulighed")]
    public bool KoeretoejOplysningTilkoblingMulighed { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningKommentar")]
    public string KoeretoejOplysningKommentar { get; set; }

    [XmlElement(ElementName = "KoeretoejBetegnelseStruktur")]
    public KoeretoejBetegnelseStruktur KoeretoejBetegnelseStruktur { get; set; }
}