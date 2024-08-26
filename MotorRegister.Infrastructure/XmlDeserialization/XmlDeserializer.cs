using System.Diagnostics;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Infrastrucutre.XmlDeserialization
{
    public class XmlDeserializer
    {
        private readonly int _bufferSize;
        private readonly ILogger<XmlDeserializer> _logger;

        public XmlDeserializer(ILogger<XmlDeserializer> logger)
        {
            _bufferSize = 1046;
            _logger = logger;
        }

        public async IAsyncEnumerable<XmlVehicle> DeserializeMotorRegisterAsync(string zipFilePath, string fileName)
        {
            using ZipArchive zipArchive = ZipFile.OpenRead(zipFilePath);
            ZipArchiveEntry? xmlFileEntry = zipArchive.GetEntry(fileName);

            if (xmlFileEntry == null)
            {
                throw new FileNotFoundException($"File {fileName} not found in the zip archive.");
            }

            await using Stream xmlFileStream = xmlFileEntry.Open();
            await foreach (XmlVehicle vehicle in ProcessXmlFileAsync(xmlFileStream))
            {
                yield return vehicle;
            }
        }

        private async IAsyncEnumerable<XmlVehicle> ProcessXmlFileAsync(Stream xmlFileStream)
        {
            BufferedStream bufferedStream = new BufferedStream(xmlFileStream, _bufferSize);
            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
                Async = true
            };

            using XmlReader reader = XmlReader.Create(bufferedStream, settings);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlVehicle));
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (await reader.ReadAsync())
            {
                if (reader is not { NodeType: XmlNodeType.Element, Name: "ns:Statistik" })
                {
                    continue;
                }
                
                XmlVehicle xmlVehicle = xmlSerializer.Deserialize(reader) as XmlVehicle;
                    
                yield return xmlVehicle;
            }

            stopwatch.Stop();
            _logger.LogInformation("Time taken: {ElapsedMilliseconds} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}