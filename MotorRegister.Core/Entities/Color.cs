using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Color
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public Color() {}

    public Color(XmlVehicleColor color)
    {
        Id = color.Type.Id;
        Name = color.Type.Name;
    }
}