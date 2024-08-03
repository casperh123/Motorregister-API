using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MotorRegisterReader.FtpDownloader;

public class FtpClient
{
    private static readonly char[] separator = new[] { ' ', '\t' };

    public static (Stream, string, long) GetFtpFile(string address, string username, string password)
    {
        FtpWebResponse directoryListing = GetDirectoryListing(address, username, password);
        string fileName = GetLatestFileName(directoryListing);

        FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(Path.Combine(address, fileName));
        downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
        downloadRequest.Credentials = new NetworkCredential(username, password);

        FtpWebResponse downloadResponse = (FtpWebResponse)downloadRequest.GetResponse();
        Stream responseStream = downloadResponse.GetResponseStream();

        long contentLength = downloadResponse.ContentLength;

        return (responseStream, fileName, contentLength);
    }

    private static FtpWebResponse GetDirectoryListing(string address, string password, string username)
    {
        FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(address);
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = new NetworkCredential(username, password);

        return (FtpWebResponse)listRequest.GetResponse();
    }
    
    private static string GetLatestFileName(FtpWebResponse response)
    {
        using StreamReader listReader = new StreamReader(response.GetResponseStream());

        List<string[]> fileDetails = [];

        while (listReader.ReadLine() is { } line)
        {
            string[] fileDetailsArray = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            fileDetails.Add(fileDetailsArray);
        }

        string[] latestFileDetails = fileDetails[^1];
        string fileName = latestFileDetails[8];
    }
}