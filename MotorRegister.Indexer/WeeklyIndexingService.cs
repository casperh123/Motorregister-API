using System.Threading.Channels;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using MotorRegister.Core.XmlModels;
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
        private const int BatchSize = 20000;

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

            while (!stoppingToken.IsCancellationRequested)
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
            using IServiceScope scope = _services.CreateScope();
            IVehicleRepository vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();
            RegisterFileDownloader registerFileDownloader = scope.ServiceProvider.GetRequiredService<RegisterFileDownloader>();
            XmlDeserializer xmlDeserializer = scope.ServiceProvider.GetRequiredService<XmlDeserializer>();

            long dataBaseOperationTime = 0;
            string zipFilePath = "./MotorRegister.zip";
            string fileName = "ESStatistikListeModtag.xml";

            var channel = Channel.CreateBounded<Vehicle>(new BoundedChannelOptions(BatchSize * 8)
            {
                SingleWriter = true,
                SingleReader = true,
                FullMode = BoundedChannelFullMode.Wait
            });

            // Producer task
            Task producer = Task.Run(async () =>
            {
                await foreach (XmlVehicle xmlVehicle in xmlDeserializer.DeserializeMotorRegisterAsync(zipFilePath, fileName).WithCancellation(stoppingToken))
                {
                    Vehicle vehicle = new Vehicle(xmlVehicle);
                    await channel.Writer.WriteAsync(vehicle, stoppingToken);
                }

                channel.Writer.Complete();
            });

            // Consumer task
            Task consumer = Task.Run(async () =>
            {
                List<Vehicle> vehicleBatch = new List<Vehicle>();

                await foreach (var vehicle in channel.Reader.ReadAllAsync(stoppingToken))
                {
                    vehicleBatch.Add(vehicle);

                    if (vehicleBatch.Count >= BatchSize)
                    {
                        dataBaseOperationTime += await vehicleRepository.AddVehiclesAsyncWithBenchmark(vehicleBatch);
                        _logger.LogInformation($"Total time spent on DB operations: {dataBaseOperationTime}");
                        vehicleBatch.Clear();
                    }
                }

                if (vehicleBatch.Count > 0)
                {
                    dataBaseOperationTime += await vehicleRepository.AddVehiclesAsyncWithBenchmark(vehicleBatch);
                    _logger.LogInformation($"Total time spent on DB operations: {dataBaseOperationTime}");
                }
            });

            await Task.WhenAll(producer, consumer);

            _logger.LogInformation("Indexing completed at: {time}", DateTimeOffset.Now);
        }

        private DateTimeOffset CalculateNextRunTime(DateTimeOffset lastRunTime)
        {
            return lastRunTime.AddDays(_intervalDays);
        }
    }
}