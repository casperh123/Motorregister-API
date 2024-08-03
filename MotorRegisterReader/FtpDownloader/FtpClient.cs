using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MotorRegisterReader.FtpDownloader
{
    public class FtpClient
    {
        private readonly string _baseAddress;
        private readonly NetworkCredential _networkCredential;

        public FtpClient(string baseAddress, string username, string password)
        {
            _baseAddress = baseAddress;
            _networkCredential = new NetworkCredential(username, password);
        }

        public async Task<(Stream, string, long)> GetRegisterFileFromPathAsync(string path)
        {
            string fullPath = Path.Combine(_baseAddress, path);
            
            FtpWebResponse directoryListing = await GetDirectoryListingAsync(fullPath);
            string fileName = GetLatestFileName(directoryListing);

            return await DownloadFileAsync(fullPath, fileName);
  
        }

        private async Task<FtpWebResponse> GetDirectoryListingAsync(string address)
        {
            FtpWebRequest listRequest = CreateFtpWebRequest(address, WebRequestMethods.Ftp.ListDirectoryDetails);
            FtpWebResponse listResponse = (FtpWebResponse)await listRequest.GetResponseAsync();
            return listResponse;
        }

        private string GetLatestFileName(FtpWebResponse response)
        {
            using StreamReader listReader = new StreamReader(response.GetResponseStream());
            List<string[]> fileDetails = new List<string[]>();

            while (listReader.ReadLine() is string line)
            {
                string[] fileDetailsArray = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                fileDetails.Add(fileDetailsArray);
            }

            string[] latestFileDetails = fileDetails[^1];
            return latestFileDetails[8];
        }

        private async Task<(Stream, string, long)> DownloadFileAsync(string address, string fileName)
        {
            FtpWebRequest downloadRequest = CreateFtpWebRequest(Path.Combine(address, fileName), WebRequestMethods.Ftp.DownloadFile);
            FtpWebResponse downloadResponse = (FtpWebResponse)await downloadRequest.GetResponseAsync();
            Stream responseStream = downloadResponse.GetResponseStream();
            long contentLength = downloadResponse.ContentLength;

            return (responseStream, fileName, contentLength);
        }

        private FtpWebRequest CreateFtpWebRequest(string address, string method)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = method;
            request.Credentials = _networkCredential;
            return request;
        }
    }
}