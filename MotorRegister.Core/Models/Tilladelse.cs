using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record Tilladelse
{
    [XmlElement(ElementName = "Tilladelse")]
    public TilladelseStruktur TilladelseStruktur { get; set; }
}