using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using MotorRegister.Infrastrucutre.FtpDownloader;

namespace MotorRegister.Indexer
{
    public class WeeklyIndexingService : BackgroundService
    {
        private readonly ILogger<WeeklyIndexingService> _logger;
        private readonly DateTimeOffset _firstRunTime;
        private readonly int _intervalDays;
        private readonly FtpClient _ftpClient;
        private readonly RegisterFileDownloader _registerFileDownloader;

        public WeeklyIndexingService(
            ILogger<WeeklyIndexingService> logger, 
            FtpClient ftpClient, 
            RegisterFileDownloader registerFileDownloader, 
            DateTimeOffset firstRunTime, 
            int intervalDays)
        {
            _logger = logger;
            _firstRunTime = firstRunTime;
            _intervalDays = intervalDays;
            _ftpClient = ftpClient;
            _registerFileDownloader = registerFileDownloader;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Weekly Indexing Service running.");
            DateTimeOffset nextRunTime = _firstRunTime;

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
                _logger.LogInformation("Next indexing scheduled for: {time}", nextRunTime);
                await Task.Delay(delay);
            }
        }

        private async Task IndexXmlToDatabaseAsync()
        {
            try
            {
                _logger.LogInformation("Starting indexing process at: {time}", DateTimeOffset.Now);
                await IndexXmlToDatabase();
                _logger.LogInformation("Indexing completed at: {time}", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred executing indexing");
            }
        }

        private async Task IndexXmlToDatabase()
        {
            // Add your logic to index XML to database
            await Task.Delay(5000); // Simulate work
        }

        private DateTimeOffset CalculateNextRunTime(DateTimeOffset lastRunTime)
        {
            return lastRunTime.AddDays(_intervalDays);
        }
    }
}
