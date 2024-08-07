using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;
using Z.EntityFramework.Extensions;

namespace MotorRegister.Infrastrucutre.Repository;

public class VehicleRepository : IVehicleRepository
{
    private MotorRegisterDbContext _database;
    private ILogger<VehicleRepository> _logger;

    public VehicleRepository(MotorRegisterDbContext database, ILogger<VehicleRepository> logger)
    {
        _database = database;
        _logger = logger;
    }

    public async Task SaveVehicle(Vehicle xmlVehicle)
    {
        await _database.AddAsync(xmlVehicle);
        await _database.SaveChangesAsync();
    }

    public async Task<Vehicle?> GetVehicleByLicensePlate(string registrationNumber)
    {
        return await _database.Vehicles
            .AsNoTracking()
            .Include(v => v.Information)
            .Include(v => v.InspectionResults)
            .FirstAsync(v => v.RegistrationNumber == registrationNumber);
    }

    public async Task<List<Vehicle>> GetVehicles(int pageSize, int page)
    {
        return await _database.Vehicles
            .AsNoTracking()
            .Include(v => v.Information)
            .Include(v => v.InspectionResults)
            .Skip(pageSize * page)
            .Take(pageSize)
            // Ensure the pageSize is used to limit the number of returned vehicles
            .ToListAsync(); // This ensures that the query is executed asynchronously and a list is returned
    }


    public async Task AddVehiclesAsync(List<Vehicle> vehicles)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        await _database.BulkInsertOptimizedAsync(vehicles, options =>
        {
            options.IncludeGraph = true;
            options.InsertIfNotExists = true;
        });
        _logger.LogInformation($"Entities saves. Time taken: {stopwatch.ElapsedMilliseconds} ms.");
    }

    public async Task<long> GetVehicleCountAsync()
    {
        return await _database.Vehicles.CountAsync();
    }
}