using MotorRegister.Core.Models;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Vehicle
{
    public string Id { get; set; }
    public string VehicleTypeName { get; set; }
    public string Usage { get; set; }
    public string? RegistrationNumber { get; set; }
    public DateTime? RegistrationNumberExpirationDate { get; set; }
    public string? RegistrationStatus { get; set; }
    public DateTime? RegistrationStatusDate { get; set; }
    
    public string InformationId { get; set; }

    public VehicleInformation Information { get; set; }
    public List<InspectionResult> InspectionResults { get; set; } = [];
    public List<Permit> Permits { get; set; } = [];

public Vehicle() { }

    public Vehicle(XmlVehicle xmlVehicle)
    {
        Id = xmlVehicle.Id;
        VehicleTypeName = xmlVehicle.VehicleTypeName;
        RegistrationNumber = xmlVehicle.RegistrationNumber;
        RegistrationNumberExpirationDate = DateTime.TryParse(xmlVehicle.RegistrationNumberExpirationDate, out var regExpDate) ? regExpDate : (DateTime?)null;
        RegistrationStatus = xmlVehicle.RegistrationStatus;
        RegistrationStatusDate = DateTime.TryParse(xmlVehicle.RegistrationStatusDate, out var regStatusDate) ? regStatusDate : (DateTime?)null;

        if (xmlVehicle.Information != null)
        {
            Information = new VehicleInformation(xmlVehicle.Information);
            InformationId = Information.ChassisNumber;
        }
        
        if (xmlVehicle.Usage != null)
        {
            Usage = xmlVehicle.Usage.Name;
        }

        if (xmlVehicle.InspectionResult != null)
        {
            foreach (XmlInspectionResult result in xmlVehicle.InspectionResult)
            {
                InspectionResults.Add(new InspectionResult(result));
            }
        }

        if (xmlVehicle.Permissions != null)
        {
            foreach(XmlPermitStructure permit in xmlVehicle.Permissions)
            {
                Permits.Add(new Permit(permit));
            }
        }
    }
}