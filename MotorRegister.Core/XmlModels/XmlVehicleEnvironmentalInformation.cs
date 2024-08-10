using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels;

public class XmlVehicleEnvironmentalInformation
{
    [XmlElement(ElementName = "KoeretoejMiljoeOplysningPartikelFilter")]
    public bool ParticleFilter { get; set; }
}