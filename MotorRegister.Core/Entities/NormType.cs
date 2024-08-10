using System;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;

namespace MotorRegister.Core.Entities;

public record NormType
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public NormType() {}

    public NormType(XmlVehicleNorm normType)
    {
        Id = normType.Type.Id.ToString();
        Name = normType.Type.Name;
    }
}