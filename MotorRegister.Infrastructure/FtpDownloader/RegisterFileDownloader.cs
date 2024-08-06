using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace MotorRegister.Infrastrucutre.FtpDownloader
{
    public class RegisterFileDownloader
    {
        private readonly FtpClient _ftpClient;
        private readonly ILogger<RegisterFileDownloader> _logger;

        public RegisterFileDownloader(FtpClient ftpClient, ILogger<RegisterFileDownloader> logger)
        {
            _ftpClient = ftpClient;
            _logger = logger;
        }
        
        public async Task<(string, string)> DownloadAndSaveRegisterFileAsync(string savePath)
        {
            (Stream ftpStream, long contentLength) = await _ftpClient.GetRegisterFileFromPathAsync("ESStatistikListeModtag");

            string newFileName = Path.Combine(savePath, "MotorRegister.zip");

            _logger.LogInformation($"Saving file to {newFileName}");

            await using FileStream outputFileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 64 * 1024, useAsync: true);
            await CopyStreamWithProgressAsync(ftpStream, outputFileStream, contentLength);
            
            return (newFileName, "ESStatistikListeModtag.xml");
        }
        
        private async Task CopyStreamWithProgressAsync(Stream source, Stream destination, long totalBytes)
        {
            byte[] buffer = new byte[64 * 1024];
            long totalBytesRead = 0;
            int bytesRead;
            Stopwatch stopwatch = Stopwatch.StartNew();
            DateTime lastReportTime = DateTime.Now;

            while ((bytesRead = await source.ReadAsync(buffer.AsMemory(0, buffer.Length))) > 0)
            {
                await destination.WriteAsync(buffer.AsMemory(0, bytesRead));
                totalBytesRead += bytesRead;

                TimeSpan timeSinceLastReport = DateTime.Now - lastReportTime;
                if (timeSinceLastReport >= TimeSpan.FromSeconds(10))
                {
                    double currentSpeed = (totalBytesRead / 1024.0 / 1024.0) / stopwatch.Elapsed.TotalSeconds;
                    double progressPercentage = (totalBytesRead / (double)totalBytes) * 100;
                    _logger.LogInformation($"Downloaded {progressPercentage:N2}% at {currentSpeed:N2} MB/s.");
                    lastReportTime = DateTime.Now;
                }
            }

            stopwatch.Stop();
            _logger.LogInformation("File download and save completed successfully.");
        }
    }
}
