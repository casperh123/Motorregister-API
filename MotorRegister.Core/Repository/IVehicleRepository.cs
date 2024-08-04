using MotorRegister.Core.Models;

namespace MotorRegister.Core.Repository;

public interface IVehicleRepository
{
    public Task SaveVehicle(Vehicle vehicle);

    public Task<Vehicle?> GetVehicleByLicensePlate(string licensePlate);
}