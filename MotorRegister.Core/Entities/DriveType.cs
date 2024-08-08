using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record DriveType
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public bool PrimaryDrive { get; set; }
    
    public DriveType() {}

    public DriveType(XmlDriveType driveType)
    {
        Id = driveType.Type.Id;
        Name = driveType.Type.Name;
        PrimaryDrive = driveType.PrimaryDrive;
    }
}