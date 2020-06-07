using System;
using System.IO;
using System.Net;
using System.Text;

namespace Orponing
{
    public class HttpRepository: IRepository
    {
        public HttpRepository(string serverUrl)
        {
            _url = serverUrl;
        }

        #region PrivateField
        private readonly string _url;
        #endregion PrivateField

        #region PrivateMethod
        private HttpWebRequest GetRequest(string method, string url)
        {
            var request = WebRequest.CreateHttp(new Uri(url));
            request.ContentType = "text/xml;charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = method;
            request.Timeout = 400000;

            return request;
        }
        private string GetResponse(HttpWebRequest request)
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        #endregion PrivateMethod

        #region PublicMethod
        public string Request(string requestBody)
        {
            HttpWebRequest request = GetRequest("POST", _url);

            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(requestBody);
            }

            return GetResponse(request);
        }
        #endregion PublicMethod     
    }
}