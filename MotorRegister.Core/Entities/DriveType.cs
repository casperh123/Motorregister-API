using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record DriveType
{
    public PowerType PowerType { get; set; }
    public bool PrimaryDrive { get; set; }
    
    public DriveType() {}

    public DriveType(XmlDriveType driveType)
    {
        PowerType = new PowerType(driveType.Type);
        PrimaryDrive = driveType.PrimaryDrive;
    }
}