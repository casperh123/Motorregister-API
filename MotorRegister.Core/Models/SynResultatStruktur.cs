using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record SynResultatStruktur
{
    [XmlElement(ElementName = "SynResultatSynsType")]
    public string SynResultatSynsType { get; set; }

    [XmlElement(ElementName = "SynResultatSynsDato")]
    public string SynResultatSynsDato { get; set; }

    [XmlElement(ElementName = "SynResultatSynsResultat")]
    public string SynResultatSynsResultat { get; set; }

    [XmlElement(ElementName = "SynResultatSynStatus")]
    public string SynResultatSynStatus { get; set; }

    [XmlElement(ElementName = "SynResultatSynStatusDato")]
    public string SynResultatSynStatusDato { get; set; }
}