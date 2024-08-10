using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlFuelStructure
{
    [XmlElement(ElementName = "KoeretoejMotorKmPerLiter")]
    public float? KilometerPerLitre{ get; set; }
}