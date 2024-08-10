using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Information
{
    public string CreatedFrom { get; set; }
    public string Status { get; set; }
    public DateTime? StatusDate { get; set; }
    public DateTime? FirstRegistrationDate { get; set; }
    public string ChassisNumber { get; set; }
    public int TotalWeight { get; set; }
    public int CurbWeight { get; set; }
    public long TechnicalTotalWeight { get; set; }
    public short AxleCount { get; set; }
    public bool TowingCapability { get; set; }
    public int TowingWeightWithoutBrakes { get; set; }
    public int TowingWeightWithBrakes { get; set; }
    public string? TypeApprovalNumber { get; set; }
    public string? Comment { get; set; }
    public Designation Designation { get; set; }
    public string? ColorId { get; set; }
    public Color? Color { get; set; }
    
    public string? NormId { get; set; }
    public NormType? Norm { get; set; }
    public bool ParticleFilter { get; set; }

    public Information() {}

    public Information(KoeretoejOplysningGrundStruktur information)
    {
        CreatedFrom = information.CreatedFrom;
        Status = information.Status;
        StatusDate = information.StatusDate;
        FirstRegistrationDate = information.FirstRegistrationDate;
        ChassisNumber = information.ChassisNumber;
        TotalWeight = information.TotalWeight;
        CurbWeight = information.CurbWeight;
        TechnicalTotalWeight = information.TechnicalTotalWeight;
        AxleCount = information.AxleCount;
        TowingCapability = information.TowingCapability;
        TowingWeightWithoutBrakes = information.TowingWeightWithoutBrakes;
        TowingWeightWithBrakes = information.TowingWeightWithBrakes;
        TypeApprovalNumber = information.TypeApprovalNumber;
        Comment = information.Comment;
        Designation = new Designation(information.Designation);
        Color = information.Color?.Type?.Name != null ? new Color(information.Color) : null;
        ColorId = Color?.Id;
        Norm = information.Norm?.Type?.Name != null ? new NormType(information.Norm) : null;
        NormId = null;
        ParticleFilter = information.EnvironmentalInformation != null
            ? information.EnvironmentalInformation.ParticleFilter
            : false;
    }
}