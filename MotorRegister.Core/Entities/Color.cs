using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Color
{
    [Key]
    public string Name { get; set; }
    
    public Color() {}

    public Color(string name)
    {
        Name = name;
    }

    public Color(XmlVehicleColor color)
    {
        Name = color.Type.Name;
    }
}