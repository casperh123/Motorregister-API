using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record PowerType
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public PowerType() {}

    public PowerType(xmlDrivePowerType powerType)
    {
        Id = powerType.Id;
        Name = powerType.Name;
    }
}