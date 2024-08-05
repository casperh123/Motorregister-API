namespace MotorRegister.Core.Models;


public record PermitType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public PermitType(MotorRegister.Core.XmlModels.XmlPermitType xmlPermitType)
    {
        Id = int.Parse(xmlPermitType.Id);
        Name = xmlPermitType.Name;
    }
}