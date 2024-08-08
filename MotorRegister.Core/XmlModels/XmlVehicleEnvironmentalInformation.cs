using System.Xml.Serialization;

namespace MotorRegister.Core.Models;

public class XmlVehicleEnvironmentalInformation
{
    [XmlElement(ElementName = "KoeretoejMiljoeOplysningPartikelFilter")]
    public bool ParticleFilter { get; set; }
}