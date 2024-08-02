using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class SynResultatStruktur
{
    [XmlElement(ElementName = "SynResultatSynsType")]
    public string SynResultatSynsType { get; set; }

    [XmlElement(ElementName = "SynResultatSynsDato")]
    public DateTime SynResultatSynsDato { get; set; }

    [XmlElement(ElementName = "SynResultatSynsResultat")]
    public string SynResultatSynsResultat { get; set; }

    [XmlElement(ElementName = "SynResultatSynStatus")]
    public string SynResultatSynStatus { get; set; }

    [XmlElement(ElementName = "SynResultatSynStatusDato")]
    public DateTime SynResultatSynStatusDato { get; set; }
}