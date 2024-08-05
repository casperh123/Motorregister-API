using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record VehicleInformation
{
    public int Id { get; set; }
    public string CreatedFrom { get; set; }
    public string Status { get; set; }
    public DateTime StatusDate { get; set; }
    public DateTime FirstRegistrationDate { get; set; }
    public string ChassisNumber { get; set; }
    public int TotalWeight { get; set; }
    public int CurbWeight { get; set; }
    public long TechnicalTotalWeight { get; set; }
    public short AxleCount { get; set; }
    public int MaxAxleLoad { get; set; }
    public int PassengerCount { get; set; }
    public bool TowingCapability { get; set; }
    public string Comment { get; set; }
    public VehicleDesignation Designation { get; set; }
    
    public VehicleInformation() { }

    public VehicleInformation(XmlVehicleInformation xmlVehicleInfo)
    {
        CreatedFrom = xmlVehicleInfo.CreatedFrom;
        Status = xmlVehicleInfo.Status;
        StatusDate = DateTime.Parse(xmlVehicleInfo.StatusDate);
        FirstRegistrationDate = DateTime.Parse(xmlVehicleInfo.FirstRegistrationDate);
        ChassisNumber = xmlVehicleInfo.ChassisNumber;
        TotalWeight = xmlVehicleInfo.TotalWeight;
        CurbWeight = xmlVehicleInfo.CurbWeight;
        TechnicalTotalWeight = xmlVehicleInfo.TechnicalTotalWeight;
        AxleCount = xmlVehicleInfo.AxleCount;
        MaxAxleLoad = xmlVehicleInfo.MaxAxleLoad;
        PassengerCount = xmlVehicleInfo.PassengerCount;
        TowingCapability = xmlVehicleInfo.TowingCapability;
        Comment = xmlVehicleInfo.Comment;

        Designation = new VehicleDesignation(xmlVehicleInfo.Designation);
    }
}