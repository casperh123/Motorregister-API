using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "TilladelseTypeStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record PermitType
{
    [XmlElement(ElementName = "TilladelseTypeNummer")]
    public string Id { get; set; }
    
    [XmlElement(ElementName = "TilladelseTypeNavn")]
    public string Name { get; set; }
}