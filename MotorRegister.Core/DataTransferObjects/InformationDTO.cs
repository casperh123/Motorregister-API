using MotorRegister.Core.Entities;

namespace MotorRegister.Api;

public record InformationDTO
{
    public string CreatedFrom { get; set; }
    public string Status { get; set; }
    public DateTime StatusDate { get; set; }
    public DateTime FirstRegistrationDate { get; set; }
    public string ChassisNumber { get; set; }
    public int TotalWeight { get; set; }
    public int CurbWeight { get; set; }
    public long TechnicalTotalWeight { get; set; }
    public int AxleCount { get; set; }
    public bool TowingCapability { get; set; }
    public int TowingWeightWithoutBrakes { get; set; }
    public int TowingWeightWithBrakes { get; set; }
    public string TypeApprovalNumber { get; set; }
    public string Comment { get; set; }
    public string Color { get; set; }
    public string Norm { get; set; }
    public bool ParticleFilter { get; set; }
    
    public InformationDTO()
    {
        CreatedFrom = "";
        Status = "";
        StatusDate = DateTime.MinValue;
        FirstRegistrationDate = DateTime.MinValue;
        ChassisNumber = "";
        TotalWeight = 0;
        CurbWeight = 0;
        TechnicalTotalWeight = 0;
        AxleCount = 0;
        TowingCapability = false;
        TowingWeightWithoutBrakes = 0;
        TowingWeightWithBrakes = 0;
        TypeApprovalNumber = "";
        Comment = "";
        Color = "";
        Norm = "";
        ParticleFilter = false;
    }

    public InformationDTO(Information information)
    {
        CreatedFrom = information.CreatedFrom;
        Status = information.Status;
        StatusDate = information.StatusDate ?? DateTime.MinValue;
        FirstRegistrationDate = information.FirstRegistrationDate ?? DateTime.MinValue;
        ChassisNumber = information.ChassisNumber;
        TotalWeight = information.TotalWeight;
        CurbWeight = information.CurbWeight;
        TechnicalTotalWeight = information.TechnicalTotalWeight;
        AxleCount = information.AxleCount;
        TowingCapability = information.TowingCapability;
        TowingWeightWithoutBrakes = information.TowingWeightWithoutBrakes;
        TowingWeightWithBrakes = information.TowingWeightWithBrakes;
        TypeApprovalNumber = information.TypeApprovalNumber ?? "";
        Comment = information.Comment ?? "";
        Color = information.Color?.Name ?? "";
        Norm = information.Norm?.Name ?? "";
        ParticleFilter = information.ParticleFilter;
    }
}