using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "Statistik", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record Vehicle
{
    [XmlElement(ElementName = "KoeretoejIdent")]
    public string Id { get; set; }

    [XmlElement(ElementName = "KoeretoejArtNummer")]
    public int VehicleTypeNumber { get; set; }

    [XmlElement(ElementName = "KoeretoejArtNavn")]
    public string VehicleTypeName { get; set; }

    [XmlElement(ElementName = "KoeretoejAnvendelseStruktur")]
    public VehicleUsage Usage { get; set; }

    [XmlElement(ElementName = "RegistreringNummerNummer")]
    public string RegistrationNumber { get; set; }

    [XmlElement(ElementName = "RegistreringNummerUdloebDato")]
    public string RegistrationNumberExpirationDate { get; set; }

    [XmlElement(ElementName = "KoeretoejOplysningGrundStruktur")]
    public VehicleInformation Information { get; set; }

    [XmlElement(ElementName = "SynResultatStruktur")]
    public InspectionResult InspectionResult { get; set; }

    [XmlElement(ElementName = "KoeretoejRegistreringStatus")]
    public string RegistrationStatus { get; set; }

    [XmlElement(ElementName = "KoeretoejRegistreringStatusDato")]
    public string RegistrationStatusDate { get; set; }

    [XmlElement(ElementName = "TilladelseSamling")]
    public List<Permit> Permissions { get; set; }
}