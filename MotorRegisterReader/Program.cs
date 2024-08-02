using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using MotorRegister.Core.Models;

string zipFilePath = "../../../../ESStatistikListeModtag-20240728-193626.zip";
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

    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Statistik));

    List<Statistik> biler = [];

    Stopwatch stopwatch = Stopwatch.StartNew();

    while (reader.Read())
    {
        if (reader.Name == "ns:Statistik")
        {

            Statistik bil = xmlSerializer.Deserialize(reader) as Statistik;

            if (bil != null && bil.KoeretoejRegistreringStatus != "Afmeldt")
            {
                biler.Add(bil);


            }
        }
    }
    stopwatch.Stop();
    Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
}