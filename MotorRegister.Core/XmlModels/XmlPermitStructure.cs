using System.Xml.Serialization;

namespace MotorRegister.Core.XmlModels
{
    [XmlRoot(ElementName = "TilladelseStruktur", Namespace = "http://skat.dk/dmr/2007/05/31/")]
    public record XmlPermitStructure
    {
        [XmlElement(ElementName = "TilladelseGyldigFra")]
        public string ValidFrom { get; set; }

        [XmlElement(ElementName ="TilladelseKommentar")]
        public string Comment { get; set; }

        [XmlIgnore]
        public string PermitTypeId
        {
            get => XmlPermitType?.Id;
            set
            {
                if (XmlPermitType != null)
                {
                    XmlPermitType.Id = value;
                }
            }
        }

        [XmlIgnore]
        public string PermitTypeName
        {
            get => XmlPermitType?.Name;
            set
            {
                if (XmlPermitType != null)
                {
                    XmlPermitType.Name = value;
                }
            }
        }

        [XmlElement(ElementName = "TilladelseTypeStruktur")]
        public XmlPermitType XmlPermitType { get; set; }
    }
}