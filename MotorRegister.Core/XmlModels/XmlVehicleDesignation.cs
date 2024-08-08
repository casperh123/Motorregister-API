using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlVehicleDesignation
{
    [XmlElement(ElementName = "KoeretoejMaerkeTypeNummer")]
    public int ManufacturerId { get; set; }

    [XmlElement(ElementName = "KoeretoejMaerkeTypeNavn")]
    public string ManufacturerName { get; set; }

    [XmlElement(ElementName = "Model")] 
    public XmlModel XmlModel { get; set; }

    [XmlElement(ElementName = "Variant")] 
    public Variant Variant { get; set; }

    [XmlElement(ElementName = "Type")] 
    public Type Type { get; set; }
}