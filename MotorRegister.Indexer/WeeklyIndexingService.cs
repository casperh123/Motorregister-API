using MotorRegister.Core.Models;
using MotorRegister.Core.Repository;
using MotorRegister.Infrastrucutre.FtpDownloader;
using MotorRegister.Infrastrucutre.XmlDeserialization;

namespace MotorRegister.Indexer
{
    public class WeeklyIndexingService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<WeeklyIndexingService> _logger;
        private readonly DateTimeOffset _firstRunTime;
        private readonly int _intervalDays;

        public WeeklyIndexingService(
            IServiceProvider services,
            ILogger<WeeklyIndexingService> logger,
            DateTimeOffset firstRunTime,
            int intervalDays)
        {
            _services = services;
            _logger = logger;
            _firstRunTime = firstRunTime;
            _intervalDays = intervalDays;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Weekly Indexing Service running.");
            DateTimeOffset nextRunTime = _firstRunTime;

            while (true)
            {
                await WaitForNextRunTime(nextRunTime, stoppingToken);
                await IndexXmlToDatabaseAsync(stoppingToken);

                nextRunTime = CalculateNextRunTime(nextRunTime);
            }
        }

        private async Task WaitForNextRunTime(DateTimeOffset nextRunTime, CancellationToken stoppingToken)
        {
            TimeSpan delay = nextRunTime - DateTimeOffset.Now;
            if (delay > TimeSpan.Zero)
            {
                _logger.LogInformation("Next indexing scheduled for: {time}", nextRunTime);
                await Task.Delay(delay, stoppingToken);
            }
        }

        private async Task IndexXmlToDatabaseAsync(CancellationToken stoppingToken)
        {
            using var scope = _services.CreateScope();
            IVehicleRepository vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();
            RegisterFileDownloader registerFileDownloader = scope.ServiceProvider.GetRequiredService<RegisterFileDownloader>();
            XmlDeserializer xmlDeserializer = scope.ServiceProvider.GetRequiredService<XmlDeserializer>();

            try
            {
                _logger.LogInformation("Starting indexing process at: {time}", DateTimeOffset.Now);

                (string zipFileName, string fileName) = await registerFileDownloader.DownloadAndSaveRegisterFileAsync(Directory.GetCurrentDirectory());

                List<Vehicle> vehicleBatch = new List<Vehicle>();
                
                await foreach (Vehicle vehicle in await xmlDeserializer.DeserializeMotorRegister(zipFileName, fileName))
                {
                    if (vehicleBatch.Count < 1000)
                    {
                        vehicleBatch.Add(vehicle);
                        continue;
                    }
                    await vehicleRepository.AddVehiclesAsync(vehicleBatch);
                    vehicleBatch.Clear();
                    vehicleBatch.Add(vehicle);
                    
                }

                // Add any remaining vehicles in the batch
                if (vehicleBatch.Count > 0)
                {
                    await vehicleRepository.AddVehiclesAsync(vehicleBatch);
                }

                _logger.LogInformation("Indexing completed at: {time}", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred executing indexing.");
            }
        }

        private DateTimeOffset CalculateNextRunTime(DateTimeOffset lastRunTime)
        {
            return lastRunTime.AddDays(_intervalDays);
        }
    }
}