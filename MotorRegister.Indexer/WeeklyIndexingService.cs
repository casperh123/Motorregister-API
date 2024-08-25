using System.Runtime.InteropServices.JavaScript;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.FtpDownloader;
using MotorRegister.Infrastrucutre.XmlDeserialization;

namespace MotorRegister.Indexer
{
    public class WeeklyIndexingService(
        IServiceProvider services,
        ILogger<WeeklyIndexingService> logger,
        DateTimeOffset firstRunTime,
        int intervalDays)
        : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Weekly Indexing Service running.");
            DateTimeOffset nextRunTime = firstRunTime;

            while (true)
            {
                await WaitForNextRunTime(nextRunTime);
                await IndexXmlToDatabaseAsync();

                nextRunTime = CalculateNextRunTime(nextRunTime);
            }
        }

        private async Task WaitForNextRunTime(DateTimeOffset nextRunTime)
        {
            TimeSpan delay = nextRunTime - DateTimeOffset.Now;
            if (delay > TimeSpan.Zero)
            {
                logger.LogInformation("Next indexing scheduled for: {time}", nextRunTime);
                await Task.Delay(delay);
            }
        }

        private async Task IndexXmlToDatabaseAsync()
        {
            using IServiceScope scope = services.CreateScope();
            IVehicleRepository vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();
            RegisterFileDownloader registerFileDownloader = scope.ServiceProvider.GetRequiredService<RegisterFileDownloader>();
            XmlDeserializer xmlDeserializer = scope.ServiceProvider.GetRequiredService<XmlDeserializer>();
            long dataBaseOperationTime = 0;
            
            try
            {
                logger.LogInformation("Starting indexing process at: {time}", DateTimeOffset.Now);

                //(string zipFilePath, string fileName) = await registerFileDownloader.DownloadAndSaveRegisterFileAsync(Directory.GetCurrentDirectory());

                List<Vehicle> vehicleBatch = [];

                string zipFilePath = "./MotorRegister.zip";
                string fileName = "ESStatistikListeModtag.xml";
                
                foreach (XmlVehicle xlmVehicle in xmlDeserializer.DeserializeMotorRegister(zipFilePath, fileName))
                {
                    Vehicle vehicle = new Vehicle(xlmVehicle);
                    if (vehicleBatch.Count < 5000)
                    {
                        vehicleBatch.Add(vehicle);
                        continue;
                    }

                    dataBaseOperationTime += await vehicleRepository.AddVehiclesAsyncWithBenchmark(vehicleBatch);
                    logger.LogDebug($"Total time spent on DB operations: {dataBaseOperationTime}");
                    vehicleBatch.Clear();
                    vehicleBatch.Add(vehicle);
                }

                if (vehicleBatch.Count > 0)
                {
                    dataBaseOperationTime += await vehicleRepository.AddVehiclesAsyncWithBenchmark(vehicleBatch);
                }

                logger.LogDebug($"Total time spent on DB operations: {dataBaseOperationTime}");
                logger.LogDebug($"Indexing completed at: {DateTimeOffset.Now}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred executing indexing.");
            }
        }

        private DateTimeOffset CalculateNextRunTime(DateTimeOffset lastRunTime)
        {
            return lastRunTime.AddDays(intervalDays);
        }
    }
}