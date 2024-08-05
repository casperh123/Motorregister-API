using MotorRegister.Core.Models;

namespace MotorRegister.Core.Repository;

public interface IVehicleRepository
{
    public Task SaveVehicle(Vehicle xmlVehicle);

    public Task<Vehicle?> GetVehicleByLicensePlate(string licensePlate);

    public Task AddVehiclesAsync(List<Vehicle> vehicles);
}