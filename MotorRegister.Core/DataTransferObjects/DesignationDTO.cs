using MotorRegister.Core.Entities;

namespace MotorRegister.Core.DataTransferObjects;

public record DesignationDTO
{
    public string ManufacturerName { get; set; }
    public string Model { get; set; }
    public string Variant { get; set; }
    public string Type { get; set; }
    
    public DesignationDTO()
    {
        ManufacturerName = "";
        Model = "";
        Variant = "";
        Type = "";
    }

    public DesignationDTO(Designation designation)
    {
        ManufacturerName = designation.ManufacturerName;
        Model = designation.Model?.Name ?? "";
        Variant = designation.Variant?.Name ?? "";
        Type = designation.Type?.Name ?? "";
    }
}