using System.Drawing;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record ColorType
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ColorType() {}

    public ColorType(XmlVehicleColor color)
    {
        Id = color.Type.Id;
        Name = color.Type.Name;
    }
}