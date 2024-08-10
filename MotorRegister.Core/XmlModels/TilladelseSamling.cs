using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

[XmlRoot(ElementName = "Tilladelse")]
public class TilladelseSamling
{
    [XmlElement(ElementName = "TilladelseStruktur")]
    public XmlPermissionDetails Details { get; set; }
}