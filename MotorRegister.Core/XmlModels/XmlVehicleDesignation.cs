using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlVehicleDesignation
{
    [XmlElement(ElementName = "KoeretoejMaerkeTypeNummer")]
    public int ManufacturerId { get; set; }

    [XmlElement(ElementName = "KoeretoejMaerkeTypeNavn")]
    public string ManufacturerName { get; set; }

    [XmlElement(ElementName = "Model")] 
    public XmlModel XmlModel { get; set; }

    [XmlElement(ElementName = "Variant")] 
    public XmlVariant XmlVariant { get; set; }

    [XmlElement(ElementName = "Type")] 
    public XmlType XmlType { get; set; }
}