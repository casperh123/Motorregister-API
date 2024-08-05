using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record Vehicle
{
    public string Id { get; set; }
    public int VehicleTypeNumber { get; set; }
    public string VehicleTypeName { get; set; }
    public int? UsageId { get; set; } 
    public VehicleUsage Usage { get; set; }
    public string RegistrationNumber { get; set; }
    public DateTime? RegistrationNumberExpirationDate { get; set; }
    public int? InformationId { get; set; }
    public VehicleInformation Information { get; set; }
    public List<InspectionResult> InspectionResults { get; set; } = [];
    public string RegistrationStatus { get; set; }
    public DateTime? RegistrationStatusDate { get; set; }
    public List<Permit> Permissions { get; set; } = [];
    
    public Vehicle() { }

    public Vehicle(XmlVehicle xmlVehicle)
    {
        Id = xmlVehicle.Id;
        VehicleTypeNumber = xmlVehicle.VehicleTypeNumber;
        VehicleTypeName = xmlVehicle.VehicleTypeName;
        RegistrationNumber = xmlVehicle.RegistrationNumber;
        RegistrationNumberExpirationDate = DateTime.TryParse(xmlVehicle.RegistrationNumberExpirationDate, out var regExpDate) ? regExpDate : (DateTime?)null;
        RegistrationStatus = xmlVehicle.RegistrationStatus;
        RegistrationStatusDate = DateTime.TryParse(xmlVehicle.RegistrationStatusDate, out var regStatusDate) ? regStatusDate : (DateTime?)null;

        // Initialize related entities
        if (xmlVehicle.Usage != null)
        {
            Usage = new VehicleUsage(xmlVehicle.Usage);
            UsageId = Usage.Id;
        }

        if (xmlVehicle.Information != null)
        {
            Information = new VehicleInformation(xmlVehicle.Information);
            InformationId = Information.Id;
        }

        foreach (XmlInspectionResult xmlInspectionResult in xmlVehicle.InspectionResult)
        {
            InspectionResults.Add(new InspectionResult(xmlInspectionResult, Id));
        }

        foreach (XmlPermitStructure xmlPermitStructure in xmlVehicle.Permissions)
        {
            Permissions.Add(new Permit(xmlPermitStructure));
        }
    }
}