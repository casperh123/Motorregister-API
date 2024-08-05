using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace MotorRegisterReader.FtpDownloader
{
    public class RegisterFileDownloader
    {
        private readonly FtpClient _ftpClient;

        public RegisterFileDownloader()
        {
            _ftpClient = new FtpClient("ftp://5.44.137.84", "dmr-ftp-user", "dmrpassword");
        }
        
        public async Task<(string, string)> DownloadAndSaveRegisterFileAsync(string path)
        {
            (Stream ftpStream, string zipFileName, long contentLength) = await _ftpClient.GetRegisterFileFromPathAsync("ESStatistikListeModtag");

            string newFileName = Path.Combine(path, "MotorRegister.zip");

            Console.WriteLine($"Saving file to {path}");
            
            await using FileStream outputFileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 64 * 1024, useAsync: true);
            await CopyStreamWithProgressAsync(ftpStream, outputFileStream, contentLength);
            
            return (zipFileName, "ESStatistikListeModtag.xml");
        }
        
        private static async Task CopyStreamWithProgressAsync(Stream source, Stream destination, long totalBytes)
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
                    Console.WriteLine($"Downloaded {progressPercentage:N2}% at {currentSpeed:N2} MB/s.");
                    lastReportTime = DateTime.Now;
                }
            }

            stopwatch.Stop();
        }
    }
}
