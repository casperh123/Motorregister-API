using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;


public record PermitType
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public PermitType() { }

    public PermitType(XmlPermitType xmlPermitType)
    {
        Id = int.Parse(xmlPermitType.Id);
        Name = xmlPermitType.Name;
    }
}