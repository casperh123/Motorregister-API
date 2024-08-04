using System.Diagnostics;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using MotorRegister.Core.Models;
using MotorRegisterReader.FtpDownloader;

const int bufferSize = 81920;

RegisterFileDownloader registerDownloader = new RegisterFileDownloader();

(string zipFileName, string fileName) = await registerDownloader.DownloadAndSaveRegisterFileAsync(Directory.GetCurrentDirectory());

using ZipArchive zipArchive = ZipFile.OpenRead(zipFileName);
ZipArchiveEntry? xmlFileEntry = zipArchive.GetEntry(fileName);

await using Stream xmlFileStream = xmlFileEntry.Open();
ProcessXmlFile(xmlFileStream);

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
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Vehicle));

        List<Vehicle> biler = new List<Vehicle>();

        Stopwatch stopwatch = Stopwatch.StartNew();

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "ns:Statistik")
            {
                Vehicle bil = xmlSerializer.Deserialize(reader) as Vehicle;
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
