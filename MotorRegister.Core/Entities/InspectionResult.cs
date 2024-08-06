using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record InspectionResult
{
    [Key]
    public int Id { get; set; } // Auto-incrementing
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string Result { get; set; }
    public string Status { get; set; }
    public DateTime StatusDate { get; set; }

    public InspectionResult() { }
    
    public InspectionResult(XmlInspectionResult xml)
    {
        Type = xml.Type;
        Date = DateTime.Parse(xml.Date); 
        Result = xml.Result;
        Status = xml.Status;
        StatusDate = DateTime.Parse(xml.StatusDate); 
    }
}