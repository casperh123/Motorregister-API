using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record KoeretoejOplysningGrundStruktur
{
    [XmlElement(ElementName = "KoeretoejOplysningOprettetUdFra")]
    public string KoeretoejOplysningOprettetUdFra { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStatus")]
    public string KoeretoejOplysningStatus { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStatusDato")]
    public string KoeretoejOplysningStatusDato { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningFoersteRegistreringDato")]
    public string KoeretoejOplysningFoersteRegistreringDato { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStelNummer")]
    public string KoeretoejOplysningStelNummer { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTotalVaegt")]
    public int KoeretoejOplysningTotalVaegt { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningEgenVaegt")]
    public int KoeretoejOplysningEgenVaegt { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTekniskTotalVaegt")]
    public long KoeretoejOplysningTekniskTotalVaegt { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningAkselAntal")]
    public short KoeretoejOplysningAkselAntal { get; set; }

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