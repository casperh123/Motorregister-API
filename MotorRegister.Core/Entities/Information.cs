using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Information
{
    [Key]
    public int VehicleId { get; set; }
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
    public string TypeApprovalNumber { get; set; }
    public string Comment { get; set; }
    public Designation Designation { get; set; }
    
    [ForeignKey("Color")]
    public long ColorId { get; set; }
    public Color Color { get; set; }
    
    [ForeignKey("Norm")]
    public int NormId { get; set; }
    public NormType Norm { get; set; }
    public bool ParticleFilter { get; set; }
    public List<DriveType> DriveTypes { get; set; }

    public Information() {}

    public Information(XmlVehicleInformation information, int vehicleId)
    {
        VehicleId = vehicleId;
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
        Designation = new Designation(information.Designation, vehicleId);
        ColorId = Color.Id;
        Color = new Color(information.Color);
        NormId = information.Norm.Type.Id;
        Norm = new NormType(information.Norm.Type);
        ParticleFilter = information.EnvironmentalInformation.ParticleFilter;
        DriveTypes = [];
        
        foreach (XmlDrive driveType in information.Motor.XmlDriveAssembly.Drives)
        {
            DriveTypes.Add(new DriveType(driveType.Type));
        }
    }
}