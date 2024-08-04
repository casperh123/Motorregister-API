using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

[XmlRoot(ElementName = "Tilladelse", Namespace = "http://skat.dk/dmr/2007/05/31/")]
public record Permit
{
    [XmlElement(ElementName = "Tilladelse")]
    public PermitStructure PermitStructure { get; set; }
}