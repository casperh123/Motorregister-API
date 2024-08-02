using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class TilladelseSamling
{
    [XmlElement(ElementName = "Tilladelse")]
    public string TilladelseList { get; set; }
}