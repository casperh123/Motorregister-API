using System.Diagnostics;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using MotorRegister.Core.Models;
using MotorRegisterReader.FtpDownloader;

namespace MotorRegister.Infrastrucutre.XmlDeserialization;

public class XmlDeserializer
{
    private int _bufferSize;
    private RegisterFileDownloader _registerDownloader;

    public XmlDeserializer(RegisterFileDownloader registerDownloader, int bufferSize)
    {
        _bufferSize = bufferSize;
        _registerDownloader = registerDownloader;
    }

    public async Task DeserializeMotorRegister(string zipFilePath, string fileName)
    {
        using ZipArchive zipArchive = ZipFile.OpenRead("../../../../ESStatistikListeModtag-20240728-193626.zip");
        ZipArchiveEntry? xmlFileEntry = zipArchive.GetEntry("ESStatistikListeModtag.xml");

        await using Stream xmlFileStream = xmlFileEntry.Open();
        ProcessXmlFile(xmlFileStream);

        void ProcessXmlFile(Stream xmlFileStream)
        {
            BufferedStream bufferedStream = new BufferedStream(xmlFileStream, _bufferSize);
            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
            };

            using (XmlReader reader = XmlReader.Create(bufferedStream, settings))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Vehicle));

                List<Vehicle> vehicles = new List<Vehicle>();

                Stopwatch stopwatch = Stopwatch.StartNew();

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ns:Statistik")
                    {
                
                        Console.WriteLine(reader.ReadOuterXml());
                        Vehicle vehicle = xmlSerializer.Deserialize(reader) as Vehicle;
                        if (vehicle != null && vehicle.RegistrationStatus != "Afmeldt")
                        {
                            vehicles.Add(vehicle);
                            if (vehicles.Count % 10000 == 0)
                            {
                                Console.WriteLine($"Read {vehicles.Count} Cars");
                            }
                        }
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
            }
        }

    } 
}