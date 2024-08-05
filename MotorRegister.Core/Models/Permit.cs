using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record Permit
{
    public DateTime ValidFrom { get; set; }
    public string Comment { get; set; }
    public int PermitTypeId { get; set; }
    public PermitType PermitType { get; set; }
    
    public Permit(XmlPermitStructure xmlPermitStructure)
    {
        ValidFrom = DateTime.Parse(xmlPermitStructure.ValidFrom); 
        Comment = xmlPermitStructure.Comment;
        PermitType = new PermitType(xmlPermitStructure.XmlPermitType);
        PermitTypeId = PermitType.Id; 
    }

}