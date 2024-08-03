using System.Diagnostics;

namespace MotorRegisterReader.FtpDownloader;

public class RegisterFileDownloader
{
    public static (string, string) DownloadAndSaveRegisterFile()
    {
        (string ftpAddress, string username, string password) = ("ftp://5.44.137.84/ESStatistikListeModtag", "dmr-ftp-user", "dmrpassword");
        (Stream ftpStream, string zipFileName, long contentLength) = FtpClient.GetFtpFile(ftpAddress, username, password);

        string newFileName = "MotorRegister.zip";
        
        using FileStream outputFileStream = new FileStream(newFileName, FileMode.Create);
        CopyStreamWithProgress(ftpStream, outputFileStream, contentLength);

        return (zipFileName, "");
    }
    
    private static void CopyStreamWithProgress(Stream source, Stream destination, long totalBytes)
    {
        byte[] buffer = new byte[81920];
        long totalBytesRead = 0;
        int bytesRead;
        Stopwatch stopwatch = Stopwatch.StartNew();
        DateTime lastReportTime = DateTime.Now;

        while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
        {
            destination.Write(buffer, 0, bytesRead);
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