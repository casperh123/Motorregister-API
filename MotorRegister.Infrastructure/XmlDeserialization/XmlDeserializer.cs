using System.Diagnostics;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using MotorRegister.Core.Models;

namespace MotorRegister.Infrastrucutre.XmlDeserialization
{
    public class XmlDeserializer
    {
        private readonly int _bufferSize;
        private readonly ILogger<XmlDeserializer> _logger;

        public XmlDeserializer(int bufferSize, ILogger<XmlDeserializer> logger)
        {
            _bufferSize = bufferSize;
            _logger = logger;
        }

        public IEnumerable<Vehicle> DeserializeMotorRegister(string zipFilePath, string fileName)
        {
            using ZipArchive zipArchive = ZipFile.OpenRead(zipFilePath);
            ZipArchiveEntry? xmlFileEntry = zipArchive.GetEntry(fileName);

            if (xmlFileEntry == null)
            {
                throw new FileNotFoundException($"File {fileName} not found in the zip archive.");
            }

            using Stream xmlFileStream = xmlFileEntry.Open();
            foreach (var vehicle in ProcessXmlFile(xmlFileStream))
            {
                yield return vehicle;
            }
        }

        private IEnumerable<Vehicle> ProcessXmlFile(Stream xmlFileStream)
        {
            BufferedStream bufferedStream = new BufferedStream(xmlFileStream, _bufferSize);
            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
            };

            using XmlReader reader = XmlReader.Create(bufferedStream, settings);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Vehicle));

            Stopwatch stopwatch = Stopwatch.StartNew();
            int extractedVehicles = 0;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "ns:Statistik")
                {
                    
                    Vehicle vehicle = xmlSerializer.Deserialize(reader) as Vehicle;
                    if (vehicle != null && vehicle.RegistrationStatus != "Afmeldt")
                    {
                        yield return vehicle;
                        extractedVehicles++;
                        if (extractedVehicles % 10000 == 0)
                        {
                            _logger.LogInformation("Read {ExtractedVehicles} vehicles", extractedVehicles);
                        }
                    }
                }
            }

            stopwatch.Stop();
            _logger.LogInformation("Time taken: {ElapsedMilliseconds} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}