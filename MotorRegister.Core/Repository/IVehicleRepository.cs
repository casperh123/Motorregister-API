using MotorRegister.Core.Entities;
using Z.EntityFramework.Extensions;

namespace MotorRegister.Core.Repository;

public interface IVehicleRepository
{
    public Task SaveVehicle(Vehicle xmlVehicle);

    public Task<Vehicle?> GetVehicleByLicensePlate(string registrationNumber);

    public Task AddVehiclesAsync(List<Vehicle> vehicles);

    public Task<List<Vehicle>> GetVehicles(int pageNumber, int page);

    public Task<long> GetVehicleCountAsync();
}