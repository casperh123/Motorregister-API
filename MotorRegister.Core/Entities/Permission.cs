using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Permission
{
    public int VehicleId { get; set; }
    public string ValidFrom { get; set; }
    public string Comment { get; set; }
    public string PermissionType { get; set; }

    
    public Permission() {}

    public Permission(XmlPermission permission, int vehicleId)
    {
        VehicleId = VehicleId;
        ValidFrom = permission.Details.ValidFrom;
        Comment = permission.Details.ValidFrom;
        PermissionType = permission.Details.Type.Name;
    }
}