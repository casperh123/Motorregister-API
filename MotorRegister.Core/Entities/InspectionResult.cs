using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record InspectionResult
{
    public int VehicleId { get; set; }
    public string Type { get; set; }
    public string Date { get; set; }
    public string Result { get; set; }
    public string Status { get; set; }
    public string StatusDate { get; set; }
    
    public InspectionResult() {}

    public InspectionResult(XmlInspectionResult inspectionResult, int vehicleId)
    {
        VehicleId = vehicleId;
        Type = inspectionResult.Type;
        Date = inspectionResult.Date;
        Result = inspectionResult.Result;
        Status = inspectionResult.Status;
        StatusDate = inspectionResult.StatusDate;
    }
}