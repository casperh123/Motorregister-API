using MotorRegister.Core.Entities;

namespace MotorRegister.Api;

public record VehicleDTO
{
    public string VehicleTypeName { get; set; }
    public string Usage { get; set; }
    public string RegistrationNumber { get; set; }
    public string RegistrationNumberExpirationDate { get; set; }
    public InformationDTO InformationDto { get; set; }
    

    public VehicleDTO(Vehicle vehicle)
    {
        
    }
}