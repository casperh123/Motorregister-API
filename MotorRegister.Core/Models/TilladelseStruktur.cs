using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record TilladelseStruktur
{
    [XmlElement(ElementName = "TilladelseGyldigFra")]
    public string TilladelseGyldigFra { get; set; }
    
    [XmlElement(ElementName ="TilladelseKommentar")]
    public string TilladelseKommentar { get; set; }
    
    [XmlElement(ElementName = "TilladelseTypeStruktur")]
    public TilladelseTypeStruktur TilladelseType { get; set; }
}