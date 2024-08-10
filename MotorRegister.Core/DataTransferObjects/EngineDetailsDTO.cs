using MotorRegister.Core.Entities;
using DriveType = MotorRegister.Core.Entities.DriveType;

namespace MotorRegister.Core.DataTransferObjects;

public record EngineDetailsDTO
{
    public float KilometerPerLitre { get; set; }
    public string FuelName { get; set; }

    public EngineDetailsDTO()
    {
        KilometerPerLitre = 0;
        FuelName = "";
    }
    
    public EngineDetailsDTO(DriveType driveType)
    {
        KilometerPerLitre = driveType.KilometersPerLitre;
        FuelName = driveType.Fuel?.Name ?? "";
    }
}