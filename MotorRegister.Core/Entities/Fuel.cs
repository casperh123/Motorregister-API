using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Fuel
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public Fuel() {}

    public Fuel(xmlDrivePowerType powerType)
    {
        Id = powerType.Id.ToString();
        Name = powerType.Name;
    }
}