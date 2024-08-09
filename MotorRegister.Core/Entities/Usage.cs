using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Usage
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public Usage() {}

    public Usage(XmlVehicleUsage type)
    {
        Id = type.Id;
        Name = type.Name;
    }
}