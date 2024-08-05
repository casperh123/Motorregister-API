using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record Permit
{
    [XmlElement(ElementName = "TilladelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
    public PermitStructure PermitStructure { get; set; }
}