using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public record TilladelseSamling
{
    [XmlElement(ElementName = "Tilladelse")]
    public List<TilladelseStruktur> TilladelseList { get; set; }
}