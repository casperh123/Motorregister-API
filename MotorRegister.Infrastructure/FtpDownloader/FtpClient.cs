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
            string fileName = await GetLatestFileNameAsync(directoryListing);

            return await DownloadFileAsync(fullPath, fileName);
  
        }

        private async Task<FtpWebResponse> GetDirectoryListingAsync(string address)
        {
            FtpWebRequest listRequest = CreateFtpWebRequest(address, WebRequestMethods.Ftp.ListDirectoryDetails);
            FtpWebResponse listResponse = (FtpWebResponse)await listRequest.GetResponseAsync();
            return listResponse;
        }

        private async Task<string> GetLatestFileNameAsync(FtpWebResponse response)
        {
            using var listReader = new StreamReader(response.GetResponseStream());
            string lastLine = null;
            string line;
            while ((line = await listReader.ReadLineAsync()) != null)
            {
                lastLine = line;
            }
            string[] latestFileDetails = lastLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return latestFileDetails[8];
        }


        private async Task<(Stream, string, long)> DownloadFileAsync(string address, string fileName)
        {
            FtpWebRequest downloadRequest = CreateFtpWebRequest(Path.Combine(address, fileName), WebRequestMethods.Ftp.DownloadFile);
            downloadRequest.UseBinary = true;
            downloadRequest.UsePassive = true;
            
            FtpWebResponse downloadResponse = (FtpWebResponse)await downloadRequest.GetResponseAsync();
            Stream responseStream = downloadResponse.GetResponseStream();
            long contentLength = downloadResponse.ContentLength;

            return (new BufferedStream(responseStream), fileName, contentLength);
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