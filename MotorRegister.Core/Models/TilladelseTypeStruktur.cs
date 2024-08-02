using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record TilladelseTypeStruktur
{
    [XmlElement(ElementName = "TilladelseTypeNummer")]
    public string TilladelseTypeNummer { get; set; }
    
    [XmlElement(ElementName = "TilladelseTypeNavn")]
    public string TilladelseTypeNavn { get; set; }
}