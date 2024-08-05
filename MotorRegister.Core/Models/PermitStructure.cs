using System.Xml.Serialization;

namespace MotorRegister.Core.Models
{
    [XmlRoot(ElementName = "TilladelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
    public record PermitStructure
    {
        [XmlElement(ElementName = "TilladelseGyldigFra")]
        public string ValidFrom { get; set; }

        [XmlElement(ElementName ="TilladelseKommentar")]
        public string Comment { get; set; }

        [XmlIgnore]
        public string PermitTypeId
        {
            get => PermitType?.Id;
            set
            {
                if (PermitType != null)
                {
                    PermitType.Id = value;
                }
            }
        }

        [XmlIgnore]
        public string PermitTypeName
        {
            get => PermitType?.Name;
            set
            {
                if (PermitType != null)
                {
                    PermitType.Name = value;
                }
            }
        }

        [XmlElement(ElementName = "TilladelseTypeStruktur")]
        public PermitType PermitType { get; set; }
    }
}