using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record DriveType
{
    public string Name { get; set; }
    public bool PrimaryDrive { get; set; }
    
    public DriveType() {}

    public DriveType(XmlDriveType driveType)
    {
        Name = driveType.Type.Name;
        PrimaryDrive = driveType.PrimaryDrive;
    }
}