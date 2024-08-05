using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "KoeretoejOplysningGrundStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record VehicleInformation
{
    [XmlElement(ElementName = "KoeretoejOplysningOprettetUdFra")]
    public string CreatedFrom { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStatus")]
    public string Status { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStatusDato")]
    public string StatusDate { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningFoersteRegistreringDato")]
    public string FirstRegistrationDate { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStelNummer")]
    public string ChassisNumber { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTotalVaegt")]
    public int TotalWeight { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningEgenVaegt")]
    public int CurbWeight { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTekniskTotalVaegt")]
    public long TechnicalTotalWeight { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningAkselAntal")]
    public short AxleCount { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStoersteAkselTryk")]
    public int MaxAxleLoad { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningPassagerAntal")]
    public int PassengerCount { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTilkoblingMulighed")]
    public bool TowingCapability { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningKommentar")]
    public string Comment { get; set; }

    [XmlElement(ElementName = "KoeretoejBetegnelseStruktur")]
    public VehicleDesignation Designation { get; set; }
}