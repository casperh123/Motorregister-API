using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class PermitCollection
{
    [XmlElement(ElementName = "Tilladelse")]
    public List<Permit> Permits;
}