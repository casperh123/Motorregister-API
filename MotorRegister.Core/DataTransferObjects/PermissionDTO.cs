using MotorRegister.Core.Entities;

namespace MotorRegister.Core.DataTransferObjects;

public class PermissionDTO
{
    public string ValidFrom { get; set; }
    public string Comment { get; set; }
    public string PermissionType { get; set; }
    
    public PermissionDTO()
    {
        ValidFrom = "";
        Comment = "";
        PermissionType = "";
    }
    
    public PermissionDTO(Permission permission)
    {
        ValidFrom = permission.ValidFrom;
        Comment = permission.Comment;
        PermissionType = permission.PermissionType;
    }
}