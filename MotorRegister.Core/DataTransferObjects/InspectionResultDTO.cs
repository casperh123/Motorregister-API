using MotorRegister.Core.Entities;

namespace MotorRegister.Core.DataTransferObjects;

public record InspectionResultDTO
{
    public string Type { get; set; }
    public string Date { get; set; }
    public string Result { get; set; }
    public string Status { get; set; }
    public string StatusDate { get; set; }
    
    public InspectionResultDTO()
    {
        Type = "Type";
        Date = "";
        Result = "";
        Status = "";
        StatusDate = "";
    }

    public InspectionResultDTO(InspectionResult inspectionResult)
    {
        Type = inspectionResult.Type;
        Date = inspectionResult.Date;
        Result = inspectionResult.Result;
        Status = inspectionResult.Status;
        StatusDate = inspectionResult.StatusDate;
    }
}