using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using MotorRegisterReader.FtpDownloader;
using MotorRegister.Core.Models;

const int bufferSize = 81920;

(string ftpAddress, string username, string password) = ("ftp://5.44.137.84/ESStatistikListeModtag", "dmr-ftp-user", "dmrpassword");
(Stream ftpStream, string zipFileName, long contentLength) = FtpClient.GetFtpFile(ftpAddress, username, password);

using (FileStream outputFileStream = new FileStream("MotorRegister.zip", FileMode.Create))
{
    CopyStreamWithProgress(ftpStream, outputFileStream, contentLength);
}

using (ZipArchive zipArchive = ZipFile.OpenRead("MotorRegister.zip"))
{
    ZipArchiveEntry? xmlFileEntry = zipArchive.GetEntry("ESStatistikListeModtag.xml");

    if (xmlFileEntry is not null)
    {
        using Stream xmlFileStream = xmlFileEntry.Open();
        ProcessXmlFile(xmlFileStream);
    }
    else
    {
        Console.WriteLine("XML file not found in the ZIP archive.");
    }
}

void ProcessXmlFile(Stream xmlFileStream)
{
    BufferedStream bufferedStream = new BufferedStream(xmlFileStream, bufferSize);
    XmlReaderSettings settings = new XmlReaderSettings
    {
        IgnoreWhitespace = true,
        IgnoreComments = true,
        IgnoreProcessingInstructions = true,
    };

    using (XmlReader reader = XmlReader.Create(bufferedStream, settings))
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Statistik));

        List<Statistik> biler = new List<Statistik>();

        Stopwatch stopwatch = Stopwatch.StartNew();

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "ns:Statistik")
            {
                Statistik bil = xmlSerializer.Deserialize(reader) as Statistik;
                if (bil != null && bil.KoeretoejRegistreringStatus != "Afmeldt")
                {
                    biler.Add(bil);
                    if (biler.Count % 10000 == 0)
                    {
                        Console.WriteLine($"Read {biler.Count} Cars");
                    }
                }
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }
}

void CopyStreamWithProgress(Stream source, Stream destination, long totalBytes)
{
    byte[] buffer = new byte[bufferSize];
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
