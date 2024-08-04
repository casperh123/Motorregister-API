using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "SynResultatStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record InspectionResult
{
    [XmlElement(ElementName = "SynResultatSynsType")]
    public string Type { get; set; }

    [XmlElement(ElementName = "SynResultatSynsDato")]
    public string Date { get; set; }

    [XmlElement(ElementName = "SynResultatSynsResultat")]
    public string Result { get; set; }

    [XmlElement(ElementName = "SynResultatSynStatus")]
    public string Status { get; set; }

    [XmlElement(ElementName = "SynResultatSynStatusDato")]
    public string StatusDate { get; set; }
}