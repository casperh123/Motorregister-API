using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlPermissionDetails
{
    [XmlElement(ElementName = "TilladelseGyldigFra")]
    public string ValidFrom { get; set; }

    [XmlElement(ElementName = "TilladelseKommentar")]
    public string Comment { get; set; }

    [XmlElement(ElementName = "TilladelseTypeStruktur")]
    public XmlPermissionType Type { get; set; }
}