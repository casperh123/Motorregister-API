using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Repository;

public interface IVehicleRepository
{
    public Task SaveVehicle(XmlVehicle xmlXmlVehicle);

    public Task<XmlVehicle?> GetVehicleByLicensePlate(string registrationNumber);

    public Task AddVehiclesAsync(List<XmlVehicle> vehicles);

    public Task<List<XmlVehicle>> GetVehicles(int pageNumber, int page);

    public Task<long> GetVehicleCountAsync();
}