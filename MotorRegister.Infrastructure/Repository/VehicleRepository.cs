using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MotorRegister.Api;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using MotorRegister.Infrastrucutre.Database;

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

    public async Task SaveVehicle(Vehicle xmlXmlVehicle)
    {
        await _database.AddAsync(xmlXmlVehicle);
        await _database.SaveChangesAsync();
    }

    public async Task<VehicleDTO?> GetVehicleByLicensePlate(string registrationNumber)
    {
        return new VehicleDTO(await _database.Vehicles
            .AsNoTracking()
            .Include(v => v.Information)
           // .Include(v => v.InspectionResults)
            .FirstAsync(v => v.RegistrationNumber == registrationNumber));
    }

    public async Task<List<VehicleDTO>> GetVehicles(int pageSize, int page)
    {
        return await _database.Vehicles
            .AsNoTracking()
            .Include(v => v.Information)
            .Include(v => v.InspectionResult)
            .Include(v => v.DriveType)
            .Include(v => v.Permissions)
            .Include(v => v.Usage)
            .OrderBy(v => v.Information.FirstRegistrationDate)
            .Skip(pageSize * page)
            .Take(pageSize)
            .Select(v => new VehicleDTO(v))
            // Ensure the pageSize is used to limit the number of returned vehicles
            .ToListAsync(); // This ensures that the query is executed asynchronously and a list is returned
    }


    public async Task AddVehiclesAsync(List<Vehicle> vehicles)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
            
        await _database.BulkInsertOptimizedAsync(vehicles.Distinct(), options =>
        {
            options.IncludeGraph = true;
            options.InsertIfNotExists = true;
        });
    }
    
    public async Task<long> AddVehiclesAsyncWithBenchmark(List<Vehicle> vehicles)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        await _database.BulkInsertOptimizedAsync(vehicles.Distinct(), options =>
        {
            options.IncludeGraph = true;
            options.InsertIfNotExists = true;
        });
        
        _logger.LogDebug($"Entities saves. Time taken: {stopwatch.ElapsedMilliseconds} ms.");

        return stopwatch.ElapsedMilliseconds;
    }

    public async Task<long> GetVehicleCountAsync()
    {
        return await _database.Vehicles.CountAsync();
    }
}