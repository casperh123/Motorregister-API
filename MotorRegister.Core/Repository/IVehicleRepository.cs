using MotorRegister.Core.Entities;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Repository;

public interface IVehicleRepository
{
    public Task SaveVehicle(Statistik xmlXmlVehicle);

    public Task<Statistik?> GetVehicleByLicensePlate(string registrationNumber);

    public Task AddVehiclesAsync(List<Statistik> vehicles);

    public Task<List<Statistik>> GetVehicles(int pageNumber, int page);

    public Task<long> GetVehicleCountAsync();
}