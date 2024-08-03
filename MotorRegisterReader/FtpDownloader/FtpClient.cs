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
    private string _baseAddress;
    private NetworkCredential _networkCredential;
    
    public FtpClient(string baseAddress, string username, string password)
    {
        _baseAddress = baseAddress;
        _networkCredential = new NetworkCredential(username, password);
    }
    
    public (Stream, string, long) GetRegisterFileFromPath(string path)
    {
        string fullPath = Path.Combine(_baseAddress, path);
        
        FtpWebResponse directoryListing = GetDirectoryListing(fullPath);
        string fileName = GetLatestFileName(directoryListing);

        FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(Path.Combine(fullPath, fileName));
        downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
        downloadRequest.Credentials = _networkCredential;

        FtpWebResponse downloadResponse = (FtpWebResponse)downloadRequest.GetResponse();
        Stream responseStream = downloadResponse.GetResponseStream();

        long contentLength = downloadResponse.ContentLength;

        return (responseStream, fileName, contentLength);
    }

    private FtpWebResponse GetDirectoryListing(string address)
    {
        FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(address);
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = _networkCredential;

        return (FtpWebResponse)listRequest.GetResponse();
    }
    
    private string GetLatestFileName(FtpWebResponse response)
    {
        using StreamReader listReader = new StreamReader(response.GetResponseStream());

        List<string[]> fileDetails = [];

        while (listReader.ReadLine() is { } line)
        {
            string[] fileDetailsArray = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            fileDetails.Add(fileDetailsArray);
        }

        string[] latestFileDetails = fileDetails[^1];
        
        return latestFileDetails[8];
    }
}