using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlVehicleInformation
{
    [XmlElement(ElementName = "KoeretoejOplysningOprettetUdFra")]
    public string CreatedFrom { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStatus")]
    public string Status { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningStatusDato")]
    public DateTime? StatusDate { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningFoersteRegistreringDato")]
    public DateTime? FirstRegistrationDate { get; set; }

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

    [XmlElement(ElementName = "KoeretoejOplysningTilkoblingMulighed")]
    public bool TowingCapability { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTilkoblingsvaegtUdenBremser")]
    public int TowingWeightWithoutBrakes { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTilkoblingsvaegtMedBremser")]
    public int TowingWeightWithBrakes { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningTypeAnmeldelseNummer")]
    public string TypeApprovalNumber { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningKommentar")]
    public string Comment { get; set; }

    [XmlElement(ElementName = "KoeretoejBetegnelseStruktur")]
    public XmlVehicleDesignation Designation { get; set; }

    [XmlElement(ElementName = "KoeretoejFarveStruktur")]
    public XmlVehicleColor? Color { get; set; }

    [XmlElement(ElementName = "KoeretoejNormStruktur")]
    public XmlVehicleNorm Norm { get; set; }

    [XmlElement(ElementName = "KoeretoejMiljoeOplysningStruktur")]
    public XmlVehicleEnvironmentalInformation EnvironmentalInformation { get; set; }

    [XmlElement(ElementName = "KoeretoejMotorStruktur")]
    public XmlVehicleMotor Motor { get; set; }
}