using MotorRegister.Indexer.Indexing;

namespace MotorRegister.Indexer
{
    public class WeeklyIndexingService : BackgroundService
    {
        private readonly ILogger<WeeklyIndexingService> _logger;
        private readonly DateTimeOffset _firstRunTime;
        private readonly int _intervalDays;
        private readonly IServiceProvider _serviceProvider;


        public WeeklyIndexingService(
            IServiceProvider serviceProvider,
            ILogger<WeeklyIndexingService> logger
        )
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _firstRunTime = DateTimeOffset.Now;;
            _intervalDays = 7;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Weekly Indexing Service running.");
            DateTimeOffset nextRunTime = _firstRunTime;

            while (!stoppingToken.IsCancellationRequested)
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    VehicleIndexer vehicleIndexer = scope.ServiceProvider.GetRequiredService<VehicleIndexer>();
                    await vehicleIndexer.IndexXmlToDatabaseAsync(stoppingToken);
                }

                nextRunTime = CalculateNextRunTime(nextRunTime);
                await WaitForNextRunTime(nextRunTime, stoppingToken);
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

        private DateTimeOffset CalculateNextRunTime(DateTimeOffset lastRunTime)
        {
            return lastRunTime.AddDays(_intervalDays);
        }
    }
}