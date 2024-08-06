using MotorRegister.Core.Entities;
using Z.EntityFramework.Extensions;

namespace MotorRegister.Core.Repository;

public interface IVehicleRepository
{
    public Task SaveVehicle(Vehicle xmlVehicle);

    public Task<Vehicle?> GetVehicleByLicensePlate(string licensePlate);

    public Task AddVehicleAsync(Vehicle vehicle);


}