using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Permit
{
    [Key]
    public int PermitId { get; set; } // Auto-incrementing
    public DateTime ValidFrom { get; set; }
    public string Comment { get; set; }
    public string PermitType { get; set; }
    
    public Permit() {}
    
    public Permit(XmlPermitStructure xmlPermitStructure)
    {
        ValidFrom = DateTime.Parse(xmlPermitStructure.ValidFrom); 
        Comment = xmlPermitStructure.Comment;
        PermitType = xmlPermitStructure.XmlPermitType.Name;
    }

}