using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlInspectionResult
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