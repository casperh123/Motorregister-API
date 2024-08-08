using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

//Represents XmlVehicleMotor and all of it's decendants
public record Motor
{
    public List<DriveType> DriveTypes { get; set; }
    
    public Motor() {}

    public Motor(XmlVehicleMotor motor)
    {
        DriveTypes = [];
        
        foreach (XmlDrive driveType in motor.XmlDriveAssembly.Drives)
        {
            DriveTypes.Add(new DriveType(driveType.Type));
        }
    }
}