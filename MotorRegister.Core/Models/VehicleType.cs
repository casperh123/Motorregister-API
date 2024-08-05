
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record VehicleType
{
    public long Id { get; set; } 
    public string Name { get; set; }
    
    public VehicleType() { }
    
    public VehicleType(XmlType xmlType)
    {
        Id = long.Parse(xmlType.Id);
        Name = xmlType.Name;
    }
}