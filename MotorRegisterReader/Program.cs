using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Xml;

string zipFilePath = "../../../../ESStatistikListeModtag-20240721-194743.zip";
string fileName = "ESStatistikListeModtag.xml";
const int bufferSize = 81920;

using ZipArchive zipArchive = ZipFile.OpenRead(zipFilePath);
ZipArchiveEntry? xmlFile = zipArchive.GetEntry(fileName);

if (xmlFile is not null)
{
    using Stream stream = xmlFile.Open();
    BufferedStream bufferedStream = new BufferedStream(stream, bufferSize);
    XmlReaderSettings settings = new XmlReaderSettings
    {
        IgnoreWhitespace = true,
        IgnoreComments = true,
        IgnoreProcessingInstructions = true,
    };
    using XmlReader reader = XmlReader.Create(bufferedStream, settings);
    
    Stopwatch stopwatch = Stopwatch.StartNew();

    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element)
        {
            if (reader.Depth == 0 || reader.LocalName == "StatistikSamling")
            {
                continue;
            }

            Console.WriteLine($"NodeType: {reader.NodeType}, Name: {reader.Name}, Depth: {reader.Depth}");
        }
        else if (reader.NodeType == XmlNodeType.Attribute)
        {
            Console.WriteLine($"Attribute - Name: {reader.Name}, Value: {reader.Value}");
        }
    }

    stopwatch.Stop();

    Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
}
else
{
    Console.WriteLine($"File {fileName} not found in the ZIP archive.");
}