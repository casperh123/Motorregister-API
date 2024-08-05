using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Repository;

public interface IVehicleRepository
{
    public Task SaveVehicle(XmlVehicle xmlVehicle);

    public Task<XmlVehicle?> GetVehicleByLicensePlate(string licensePlate);

    public Task AddVehiclesAsync(List<XmlVehicle> vehicles);
}