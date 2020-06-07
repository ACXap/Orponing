using Orponing;
using System.IO;

namespace OrponingTest
{
    public class FileRepository : IRepository
    {
        public FileRepository(string serverUrl)
        {
            _file = serverUrl;
        }

        private readonly string _file;

        public string Request(string requestBody)
        {
            return File.ReadAllText(_file);
        }
    }
}