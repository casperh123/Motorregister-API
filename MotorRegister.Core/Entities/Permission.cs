using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Permission
{
    public long Id { get; set; }
    public string ValidFrom { get; set; }
    public string Comment { get; set; }
    public string PermissionType { get; set; }

    
    public Permission() {}

    public Permission(XmlPermission permission, long vehicleId)
    {
        Id = vehicleId;

        if (permission.Details != null)
        {
            ValidFrom = permission.Details.ValidFrom ?? "";
            Comment = permission.Details.ValidFrom ?? "";
            PermissionType = permission.Details.Type.Name ?? "";    
        }
        else
        {
            ValidFrom = "";
            Comment = "";
            PermissionType = "";
        }
    }
}