using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Vehicle
{
    [Key]
    public string Id { get; set; }
    public int VehicleTypeNumber { get; set; }
    public string VehicleTypeName { get; set; }
    
    [ForeignKey("Usage")]
    public int UsageId { get; set; }
    public Usage Usage { get; set; }
    public string RegistrationNumber { get; set; }
    public string RegistrationNumberExpirationDate { get; set; }
    
    [ForeignKey("Information")]
    public int InformationId { get; set; }
    public Information Information { get; set; }
    public List<InspectionResult> InspectionResults { get; set; }
    public string RegistrationStatus { get; set; }
    public string RegistrationStatusDate { get; set; }
    public List<Permission> Permissions { get; set; }
    
    public Vehicle() {}

    public Vehicle(XmlVehicle vehicle)
    {
        
    }
}