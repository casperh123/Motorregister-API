using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels
{
    [XmlRoot(ElementName = "SynResultatStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
    public record XmlInspectionResult
    {
        [XmlIgnore]
        public int VehicleId { get; set; }  // Parent key to be set programmatically

        [XmlElement(ElementName = "SynResultatSynsType")]
        public string Type { get; set; }

        [XmlElement(ElementName = "SynResultatSynsDato")]
        public string Date { get; set; }

        [XmlElement(ElementName = "SynResultatSynsResultat")]
        public string Result { get; set; }

        [XmlElement(ElementName = "SynResultatSynStatus")]
        public string Status { get; set; }

        [XmlElement(ElementName = "SynResultatSynStatusDato")]
        public string StatusDate { get; set; }
    }
}