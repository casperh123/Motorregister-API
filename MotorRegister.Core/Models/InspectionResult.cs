using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record InspectionResult
{
    public string VehicleId { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string Result { get; set; }
    public string Status { get; set; }
    public DateTime StatusDate { get; set; }

    // Constructor that takes the XML class instance
    public InspectionResult(XmlInspectionResult xml, string vehicleId)
    {
        VehicleId = vehicleId;
        Type = xml.Type;
        Date = DateTime.Parse(xml.Date);  // Assuming the date is in a parsable format
        Result = xml.Result;
        Status = xml.Status;
        StatusDate = DateTime.Parse(xml.StatusDate);  // Assuming the date is in a parsable format
    }

    // Parameterless constructor for EF Core
    public InspectionResult() { }
}