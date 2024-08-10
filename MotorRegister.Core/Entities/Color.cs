using System;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;

namespace MotorRegister.Core.Entities;

public record Color
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    
    public Color() {}

    public Color(XmlVehicleColor color)
    {
        Id = color.Type.Id.ToString();
        Name = color.Type.Name;
    }
}