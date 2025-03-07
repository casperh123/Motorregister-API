using MotorRegister.Api;
using MotorRegister.Core.Entities;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Repository;

public interface IVehicleRepository
{
    public Task SaveVehicle(Vehicle xmlXmlVehicle);

    public Task<VehicleDTO> GetVehicleByLicensePlate(string registrationNumber);

    public Task AddVehiclesAsync(List<Vehicle> vehicles);

    public Task<long> AddVehiclesAsyncWithBenchmark(List<Vehicle> vehicles);


    public Task<List<VehicleDTO>> GetVehicles(int pageNumber, int page);
    

    public Task<long> GetVehicleCountAsync();
}