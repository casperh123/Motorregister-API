﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using MotorRegisterReader.FtpDownloader;
using MotorRegister.Core.Models;

const int bufferSize = 81920;

RegisterFileDownloader registerDownloader = new RegisterFileDownloader();

(string zipFileName, string fileName) = registerDownloader.DownloadAndSaveRegisterFile();

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
