using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record VehicleUsage
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public VehicleUsage() {}
    
    public VehicleUsage(XmlVehicleUsage xmlVehicleUsage)
    {
        Id = xmlVehicleUsage.Id;
        Name = xmlVehicleUsage.Name;
    }
}