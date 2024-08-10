using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record DriveType
{
    public Guid VehicleId { get; set; }
    public float KilometersPerLitre { get; set; }
    public string FuelId { get; set; }
    public Fuel Fuel { get; set; }
    public bool PrimaryDrive { get; set; }

    public DriveType() {}

    public DriveType(XmlDrive driveType, Guid vehicleId)
    {
        VehicleId = vehicleId;
        Fuel = new Fuel(driveType.Type.Type);
        FuelId = Fuel.Id;
        KilometersPerLitre = driveType.Type.Fuel?.KilometerPerLitre ?? 0;
        PrimaryDrive = driveType.Type.PrimaryDrive;
    }
}