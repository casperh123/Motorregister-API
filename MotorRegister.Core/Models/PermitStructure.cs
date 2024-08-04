using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "TilladelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record PermitStructure
{
    [XmlElement(ElementName = "TilladelseGyldigFra")]
    public string ValidFrom { get; set; }
    
    [XmlElement(ElementName ="TilladelseKommentar")]
    public string Comment { get; set; }
    
    [XmlElement(ElementName = "TilladelseTypeStruktur")]
    public PermitType PermitType { get; set; }
}