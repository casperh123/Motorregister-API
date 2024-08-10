using System.ComponentModel;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;


namespace MotorRegister.Core.Entities;

public record Usage
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    
    public Usage() {}

    public Usage(XmlVehicleUsage type)
    {
        if (type != null)
        {
            Id = GuidParser.ConvertIntToGuid(type.Id);
            Name = type.Name;
        }
        else
        {
            Id = null;
            Name = null;
        }
    }
}